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

        //Node2 currentNode = new Node2();
        //List<Node2> nodeList = new List<Node2>();
        //List<Node2> nodeSession = new List<Node2>();
        //List<string> options = new List<string>();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ConversationStartedAsync);
        }

        public async Task ConversationStartedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            supportLUIS luisAnswer = await LUISTypeParser.ParseUserInput(message.Text);
            var intent = luisAnswer.intents[0].intent;
            intent = intent == "None"|| intent == "Affirmative" || intent == "Negative" ? "Greeting" : intent;
            using (var db = new LeapChatBotDBEntities())
            {
                var intentQuery = from c in db.Intent where c.IntentName == intent select c.ID;
                var intentNodeID = intentQuery.ToArray()[0];
                var nodeQuery = from c in db.Node where c.ID == intentNodeID select c;
                foreach(var item in nodeQuery)
                {
                    MessagesController.currentNode.ID = item.ID;
                    MessagesController.currentNode.Question = item.Question;
                    MessagesController.currentNode.Answer = item.Answer;
                    MessagesController.nodeSession.Add(MessagesController.currentNode);
                }

                var results = db.GetAllConnectedNodes(MessagesController.currentNode.ID).ToList();
                MessagesController.options.Clear();
                results.ForEach(x => MessagesController.options.Add(x.Answer));
                foreach (var item in results)
                {
                    Node2 n = new Node2();
                    n.ID = item.ID;
                    n.Question = item.Question;
                    n.Answer = item.Answer;
                    MessagesController.nodeList.Add(n);
                }
            }

            PromptDialog.Choice(
                context: context,
                resume: ResumeAndPromptPlatformAsync,
                options: MessagesController.options.ToArray(),
                prompt: "Welcome to Azure Support bot! " + MessagesController.currentNode.Question,
                retry: "I didn't understand. Please try again.");
        }

        public async Task ResumeAndPromptPlatformAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var message = await argument;
            
            
            //else if (message == "Continue") {}
            if(!MessagesController.isBackOrStartOver)
            {
                foreach (var node in MessagesController.nodeList)
                {
                    if (node.Answer == message)
                        MessagesController.currentNode = node;
                }
                MessagesController.nodeSession.Add(MessagesController.currentNode);
            }
            for (int i = 1; i < MessagesController.nodeSession.Count - 1; i++)
            {
                if ((MessagesController.nodeSession[MessagesController.nodeSession.Count - 2] == MessagesController.nodeSession[i - 1] && MessagesController.currentNode.ID == MessagesController.nodeSession[i].ID) && MessagesController.nodeSession.IndexOf(MessagesController.nodeSession[MessagesController.nodeSession.Count - 2]) != MessagesController.nodeSession.IndexOf(MessagesController.nodeSession[i - 1]))
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
                var results = db.GetAllConnectedNodes(MessagesController.currentNode.ID).ToList();

                MessagesController.nodeList.Clear();
                MessagesController.options.Clear();
                foreach (var item in results)
                {
                    Node2 n = new Node2();
                    n.ID = item.ID;
                    n.Question = item.Question;
                    n.Answer = item.Answer;
                    MessagesController.nodeList.Add(n);
                }
                MessagesController.nodeList.ForEach(x => MessagesController.options.Add(x.Answer));
            }
            if(MessagesController.nodeSession.Count>1 && MessagesController.currentNode.ID!=1)
                MessagesController.options.Add("Go Back");
            PromptDialog.Choice(
                context: context,
                resume: ResumeAndPromptPlatformAsync,
                options: MessagesController.options.ToArray(),
                prompt: MessagesController.currentNode.Question,
                retry: "I didn't understand. Please try again.");

        }
    }
}
