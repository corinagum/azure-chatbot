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

        Node test = new Node() { question = "You chose SSH connectivity issues, which deployment model did you use?", answers = new Dictionary<int, string> { { 1, "Resource" }, { 2, "Classic" } } };


        string description;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ConversationStartedAsync);
        }

        public async Task ConversationStartedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            //await context.PostAsync(message.Text);

            supportLUIS luisAnswer = await LUISTypeParser.ParseUserInput(message.Text);
            var intent = luisAnswer.intents[0].intent;
            //Query DB using LUIS intent, return relevant root node

            PromptDialog.Choice(
                context: context,
                resume: ResumeAndPromptPlatformAsync,
                options: test.answers.Values.ToArray(),
                prompt: "Welcome to Azure Support bot! " + test.question,
                retry: "I didn't understand. Please try again.");
        }

        public async Task ResumeAndPromptPlatformAsync(IDialogContext context, IAwaitable<string> argument)
        {
            int id = 0;
            var reply = await argument;
            foreach (var key in test.answers.Keys)
            {
                if (test.answers[key] == reply)
                    id = key;
            }
            //Given the answer, use it's ID from above to query for the related node
            //Convert DB reply into Node structure

            Node test1 = new Node() { question = @"'You can reset credentials or SSHD using either Azure CLI commands directly or using the Azure VM Access for Linux extension. 
                How would you like to resolve the issue?'", answers = new Dictionary<int, string> { { 1, "First answer" }, { 2, "Second answer" }, { 3, "Third answer" }, { 4, "error code" }, { 5, "human" } } };

            Node test2 = new Node() { question = @"'Reset SSHD 
The SSHD configuration itself may be misconfigured or the service encountered an error. You can reset SSHD to make sure the SSH configuration itself is valid.'", answers = new Dictionary<int, string> { { 1, "Blah" }, { 2, "Blah blah" }, { 3, "Blah blah blah" } } };

            test = id == 1 ? test1 : test2;

                PromptDialog.Choice(
                        context: context,
                        resume: ResumeAndPromptPlatformAsync,
                        options: test.answers.Values.ToArray(),
                        prompt: test.question,
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
