using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace ChatBot
{
    [Serializable]
    class NodeChatBot : IDialog<object>
    {

        //Node currentNode = new Node() { Question = "You chose SSH connectivity issues, which deployment model did you use?", Answer = "Answer" };
        //string[] options = new string[] { "option1", "option2" };
        Node currentNode = new Node();
        List<Node> nodeList = new List<Node>();
        //List<string> options = new List<string>() { "option1", "option2" };
        List<string> options = new List<string>();
        string description;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ConversationStartedAsync);
        }

        public async Task ConversationStartedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            //await context.PostAsync(message.Text);

            //supportLUIS luisAnswer = await LUISTypeParser.ParseUserInput(message.Text);
            //var intent = luisAnswer.intents[0].intent;
            //Query DB using LUIS intent, return relevant root node

            using (var db = new SampleDBEntities())
            {
                var query = from c in db.Node
                            where c.id == 5
                            select c;
                foreach (var item in query)
                {
                    currentNode.id = item.id;
                    currentNode.Question = item.Question;
                    currentNode.Answer = item.Answer;
                    currentNode.Luis_id = item.Luis_id;
                    currentNode.Luis_key = item.Luis_key;
                }

                var results = db.GetAllConnectedNodes(currentNode.id).ToList();
                results.ForEach(x => options.Add(x.Answer));
                foreach(var item in results)
                {
                    Node n = new Node();
                    n.id = item.id;
                    n.Question = item.Question;
                    n.Answer = item.Answer;
                    nodeList.Add(n);
                }


            }


            PromptDialog.Choice(
                context: context,
                resume: ResumeAndPromptPlatformAsync,
                options: options.ToArray(),
                prompt: "Welcome to Azure Support bot! " + currentNode.Question,
                retry: "I didn't understand. Please try again.");
        }

        public async Task ResumeAndPromptPlatformAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var message = await argument;
            foreach (var node in nodeList)
            {
                if (node.Answer == message)
                    currentNode = node;
            }
            //Given the answer, use it's ID from above to query for the related node
            //Convert DB reply into Node structure

            using (var db = new SampleDBEntities())
            {
                var results = db.GetAllConnectedNodes(currentNode.id).ToList();

                nodeList.Clear();
                options.Clear();
                foreach (var item in results)
                {
                    Node n = new Node();
                    n.id = item.id;
                    n.Question = item.Question;
                    n.Answer = item.Answer;
                    nodeList.Add(n);
                }
                nodeList.ForEach(x => options.Add(x.Answer));

            }
                PromptDialog.Choice(
                    context: context,
                    resume: ResumeAndPromptPlatformAsync,
                    options: options.ToArray(),
                    prompt: currentNode.Question,
                    retry: "I didn't understand. Please try again.");

        }

        public async Task ResumeAndPromptDescriptionAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var temp = await argument;

            PromptDialog.Text(
                context: context,
                resume: ResumeAndPromptSummaryAsync,
                prompt: "Please provide a detailed description of the problem:",
                retry: "I didn't understand. Please try again.");
        }

        public async Task ResumeAndPromptSummaryAsync(IDialogContext context, IAwaitable<string> argument)
        {
            description = await argument;

            PromptDialog.Confirm(
                context: context,
                resume: ResumeAndHandleConfirmAsync,
                prompt: $"You entered '', and '{description}'. Is that correct?",
                retry: "I didn't understand. Please try again.");
        }

        public async Task ResumeAndHandleConfirmAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            bool choicesAreCorrect = await argument;

            if (choicesAreCorrect)
                await context.PostAsync("Your bug report has been submitted. Thanks for the feedback!");
            else
                await context.PostAsync("I see. You're welcome to try again.");

            context.Wait(ConversationStartedAsync);
        }
    }
}
