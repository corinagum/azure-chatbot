using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder.Dialogs;
using ChatBotNewDB;
using System.Collections.Generic;

namespace ChatBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public static Node2 currentNode = new Node2();
        public static List<Node2> nodeList = new List<Node2>();
        public static List<Node2> nodeSession = new List<Node2>();
        public static List<string> options = new List<string>();
        public static bool isBackOrStartOver;

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            if (activity.Type == ActivityTypes.Message)
            {
                isBackOrStartOver = false;
                if (activity.Text.ToLower() == "go back" || activity.Text.ToLower() == "back")
                {
                    nodeSession.RemoveAt(nodeSession.Count - 1);
                    currentNode = nodeSession.Last();
                    isBackOrStartOver = true;
                }
                else if (activity.Text.ToLower() == "start over")
                {
                    using (var db = new LeapChatBotDBEntities())
                    {
                        var getGreetingNode = from c in db.Node where c.ID == 1 select c;
                        var newCurrentNode = getGreetingNode.ToArray()[0];
                        currentNode.ID = newCurrentNode.ID;
                        currentNode.Answer = newCurrentNode.Answer;
                        currentNode.Question = newCurrentNode.Question;
                    }
                    nodeSession.Clear();
                    nodeSession.Add(currentNode);
                    activity.Text = nodeList[0].Answer;
                    isBackOrStartOver = true;
                }
                else if (activity.Text=="1"|| activity.Text == "2" || activity.Text == "3" || activity.Text == "4" || activity.Text == "5" || activity.Text == "6" || activity.Text == "7" || activity.Text == "8")
                {
                    var option = int.Parse(activity.Text);
                    if(option >= 1 && option <= nodeList.Count)
                        activity.Text = nodeList[option-1].Answer;
                    else if(option==nodeList.Count+1 && currentNode.ID != 1)
                    {
                        activity.Text = "Go Back";
                        nodeSession.RemoveAt(nodeSession.Count - 1);
                        currentNode = nodeSession.Last();
                        isBackOrStartOver = true;
                    }
                }

                if (activity.Text.ToLower() == "help")
                {
                    Activity reply = activity.CreateReply("You may type commands such as back, restart, human, or error code if you have a code to paste in. To return, type your answer to the previous question.");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                else if (activity.Text.ToLower() == "human")
                {
                    Activity reply = activity.CreateReply("I'm sorry I couldn't help you solve your problem. Please call 1-855-463-6889 to speak with a human.");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                else
                {
                    supportLUIS luisAnswer = await LUISTypeParser.ParseUserInput(activity.Text);
                    var intent = luisAnswer.intents[0].intent;
                    activity.Text = intent == "Affirmative" ? "yes" : intent == "Negative" ? "no" : activity.Text;
                    await Conversation.SendAsync(activity, () => new NodeChatBot());
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }


        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
                //Handle ping
            }

            return null;
        }

    }
}