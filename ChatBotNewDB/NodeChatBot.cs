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

        Node currentNode = new Node();
        List<Node> nodeList = new List<Node>();
        List<string> options = new List<string>();

        // Create list to hold the Nodes user has chosen
        List<Node> chatHistory = new List<Node>();
        // Pointer to keep track of the current index in the chatHistory list 
        int historyPointer;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ConversationStartedAsync);
        }

        public async Task ConversationStartedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            supportLUIS luisAnswer = await LUISTypeParser.ParseUserInput(message.Text);
            var intent = luisAnswer.intents[0].intent;
            int rootId = intent == "SSH" ? 2 : intent == "None" ? 1 : intent == "Performance" ? 3 : 1;
            using (var db = new LeapChatBotDBEntities())
            {
                var query = from c in db.Node
                            where c.ID == rootId
                            select c;
                foreach (var item in query)
                {
                    currentNode.ID = item.ID;
                    currentNode.Question = item.Question;
                    currentNode.Answer = item.Answer;
                }

                // Add first node to chat history list
                chatHistory.Add(currentNode);
                // Initialize historyPointer to 0
                historyPointer = 0;

                var results = db.GetAllConnectedNodes(currentNode.ID).ToList();
                results.ForEach(x => options.Add(x.Answer));
                foreach (var item in results)
                {
                    Node n = new Node();
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

            if (message.ToLower() == "back")
            {
                currentNode = chatHistory[historyPointer - 1];
                historyPointer -= 1;
            }
            else if (message.ToLower() == "restart")
            {
                currentNode = chatHistory[0];
                historyPointer = 0;
            } else
            {
                foreach (var node in nodeList)
                {
                    if (node.Answer == message)
                        currentNode = node;
                }
                // Add current node to the list containing chat history
                chatHistory.Add(currentNode);
                // Increment 
                historyPointer += 1;
            }


            using (var db = new LeapChatBotDBEntities())
            {
                var results = db.GetAllConnectedNodes(currentNode.ID).ToList();

                nodeList.Clear();
                options.Clear();
                foreach (var item in results)
                {
                    Node n = new Node();
                    n.ID = item.ID;
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
    }
}
