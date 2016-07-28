using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using ChatBotNewDB;
using System.Diagnostics;

namespace ChatBot
{
    [Serializable]
    class NodeChatBot : IDialog<object>
    {

        Node2 currentNode = new Node2();
        List<Node2> nodeList = new List<Node2>();
        List<Node2> nodeSession = new List<Node2>();
        List<string> options = new List<string>();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ConversationStartedAsync);
        }

        public async Task ConversationStartedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            supportLUIS luisAnswer = await LUISTypeParser.ParseUserInput(message.Text);
            var intent = luisAnswer.intents[0].intent;
            using (var db = new LeapChatBotDBEntities())
            {
                var intentQuery = from c in db.Intent where c.IntentName == intent select c.ID;
                var intentNodeID = intentQuery.ToArray()[0];
                var nodeQuery = from c in db.Node where c.ID == intentNodeID select c;
                foreach(var item in nodeQuery)
                {
                    currentNode.ID = item.ID;
                    currentNode.Question = item.Question;
                    currentNode.Answer = item.Answer;
                    nodeSession.Add(currentNode);
                }

                var results = db.GetAllConnectedNodes(currentNode.ID).ToList();
                results.ForEach(x => options.Add(x.Answer));
                foreach (var item in results)
                {
                    Node2 n = new Node2();
                    n.ID = item.ID;
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
            if(message=="Go Back")
            {
                nodeSession.RemoveAt(nodeSession.Count - 1);
                currentNode = nodeSession.Last();
            }
            else if(message=="Start Over")
            {
                currentNode = nodeSession.First();
                nodeSession.RemoveRange(1, nodeSession.Count - 2);
            }
            else if (message == "Continue") {}
            else
            {
                foreach (var node in nodeList)
                {
                    if (node.Answer == message)
                        currentNode = node;
                }
                nodeSession.Add(currentNode);
            }
            for (int i = 1; i < nodeSession.Count - 1; i++)
            {
                if ((nodeSession[nodeSession.Count - 2] == nodeSession[i - 1] && currentNode.ID == nodeSession[i].ID) && nodeSession.IndexOf(nodeSession[nodeSession.Count - 2]) != nodeSession.IndexOf(nodeSession[i - 1]))
                {
                    PromptDialog.Choice(
                        context: context,
                        resume: ResumeAndPromptPlatformAsync,
                        options: new string[] { "Go Back", "Continue", "Start Over" },
                        prompt: "It looks like you hit a loop, what would you like to do?",
                        retry: "I didn't understand. Please try again.");
                }
            }

            using (var db = new LeapChatBotDBEntities())
            {
                var results = db.GetAllConnectedNodes(currentNode.ID).ToList();

                nodeList.Clear();
                options.Clear();
                foreach (var item in results)
                {
                    Node2 n = new Node2();
                    n.ID = item.ID;
                    n.Question = item.Question;
                    n.Answer = item.Answer;
                    nodeList.Add(n);
                }
                nodeList.ForEach(x => options.Add(x.Answer));
            }
            if(nodeSession.Count>1)
                options.Add("Go Back");
            PromptDialog.Choice(
                context: context,
                resume: ResumeAndPromptPlatformAsync,
                options: options.ToArray(),
                prompt: currentNode.Question,
                retry: "I didn't understand. Please try again.");

        }
    }
}
