using ChatBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIforDB
{
    public partial class Form1 : Form
    {
        Node[] nodeList;
        Node currentNode;
        public Form1()
        {
            InitializeComponent();
        }

        private void ResultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(!IDradioButton.Checked && !ParentIDradioButton.Checked && !ChildIDradioButton.Checked && !QuestionRadioButton.Checked)
            {
                SearchErrorLabel.Text = "Please select one of the radio buttions";
                return;
            }
            if (SearchTextBox.Text.Length == 0)
            {
                SearchErrorLabel.Text = "The search box cannot be empty";
                return;
            }
            nodeList = setNodes();
            ResultsListBox.Items.Clear();
            ResultsListBox.Items.Add("ID\t#Kids\tQuestion");
            foreach (var node in nodeList)
                ResultsListBox.Items.Add(node.id+"\t"+ node.children.Count+ "\t"+node.question);
            SearchErrorLabel.Text = "";

        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SetCurrentNode(nodeList[ResultsListBox.SelectedIndex - 1]);
        }

        private void SetCurrentNode(Node currNode)
        {
            bool hasAnswer;
            currentNode = currNode;
            CurrentNodeParents.Text = "";
            CurrentNodeChildren.Text = "";
            CurrentNodeAnswer.Text = currentNode.answer;
            CurrentNodeID.Text = currentNode.id.ToString();
            CurrentNodeQuestion.Text = currentNode.question;
            foreach (int id in currentNode.parents)
                CurrentNodeParents.Text += id.ToString() + "  ";
            foreach (int id in currentNode.children)
            {
                hasAnswer = false;
                foreach (Node n in nodeList)
                {
                    if (id == n.id)
                    {
                        CurrentNodeChildren.Text += n.id.ToString() + " - " + n.answer + "\n";
                        hasAnswer = true;
                    }
                }
                if(!hasAnswer)
                    CurrentNodeChildren.Text += id + " - " + "No answer found \n";
            }
        }

        private Node[] setNodes()
        {
            Node currentNode = new Node()
            {
                question = "Hello, this is the question?",
                id = 1,
                children = new List<int> { 725, 163, 12 },
                parents = new List<int> { 423, 142, 645, 867 },
                answer = "Some answer"
            };

            Node currentNode1 = new Node()
            {
                question = "Hello, this is the question?",
                id = 725,
                children = new List<int> { 1, 2, 3, 4, 5 },
                parents = new List<int> { 423, 142, 645, 867 },
                answer = "First answer"
            };

            Node currentNode2 = new Node()
            {
                question = "Hello, this is the question?",
                id = 163,
                children = new List<int> { 6, 7, 8, 9, 10 },
                parents = new List<int> { 423, 142, 645, 867 },
                answer = "Second answer"
            };

            Node currentNode3 = new Node()
            {
                question = "Hello, this is the question?",
                id = 12,
                children = new List<int> { 11, 12, 13, 14, 15 },
                parents = new List<int> { 423, 142, 645, 867 },
                answer = "Third answer"
            };

            return new Node[] { currentNode, currentNode1, currentNode2, currentNode3 };
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            bool hasAnswer;
            QuestionEditTextBox.Text = CurrentNodeQuestion.Text;
            ChildrenEditTextBox.Clear();
            ParentsEditTextBox.Clear();
            foreach (int id in currentNode.children)
            {
                hasAnswer = false;
                foreach (Node n in nodeList)
                {
                    if (id == n.id)
                    {
                        ChildrenEditTextBox.Text += n.id.ToString();
                        hasAnswer = true;
                        if (id != currentNode.children[currentNode.children.Count-1])
                            ChildrenEditTextBox.Text += ", ";
                    }
                }
                if (!hasAnswer)
                {
                    ChildrenEditTextBox.Text += id.ToString();
                    if (id != currentNode.children[currentNode.children.Count-1])
                        ChildrenEditTextBox.Text += ", ";
                }
            }
            IDeditTextBox.Text = CurrentNodeID.Text;
            AnswerEditTextBox.Text = CurrentNodeAnswer.Text;
            string[] str = CurrentNodeParents.Text.Split(' ');
            CurrentNodeParents.Visible = CurrentNodeParents.Visible == false ? true : false;
            ParentsEditTextBox.Visible = ParentsEditTextBox.Visible==false ? true : false;
            for(int i=0; i<str.Length; i++)
            {
                if (str[i] == "" && i<str.Length-2)
                    ParentsEditTextBox.Text += ", ";
                ParentsEditTextBox.Text += str[i];
            }
            CurrentNodeQuestion.Visible = CurrentNodeQuestion.Visible==false ? true:false;
            QuestionEditTextBox.Visible = QuestionEditTextBox.Visible==false ? true:false;

            CurrentNodeAnswer.Visible = CurrentNodeAnswer.Visible == false ? true : false;
            AnswerEditTextBox.Visible = AnswerEditTextBox.Visible == false ? true : false;

            CurrentNodeChildren.Visible = CurrentNodeChildren.Visible==false ? true:false;
            ChildrenEditTextBox.Visible = ChildrenEditTextBox.Visible==false ? true : false;

            ConventionTextBox.Visible = ConventionTextBox.Visible == false ? true : false;

            CurrentNodeID.Visible = CurrentNodeID.Visible == false ? true : false;
            IDeditTextBox.Visible = IDeditTextBox.Visible==false ? true : false;

            SubmitEditButton.Visible = SubmitEditButton.Visible==false ? true : false;
        }

        private void SubmitEditButton_Click(object sender, EventArgs e)
        {
            currentNode.question = QuestionEditTextBox.Text;
            string[] tempStr = ParentsEditTextBox.Text.Split(',');
            List<int> tempInt = new List<int>();
            for (int i = 0; i < tempStr.Length; i++)
                tempInt.Add(int.Parse(tempStr[i]));
            currentNode.parents = tempInt;

            string[] tempStr2 = ChildrenEditTextBox.Text.Split(',');
            List<int> tempInt2 = new List<int>();
            for (int i = 0; i < tempStr2.Length; i++)
                tempInt2.Add(int.Parse(tempStr2[i]));
            currentNode.children = tempInt2;

            SetCurrentNode(currentNode);
            EditButton_Click(sender,e);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Node temp = new Node();
            if (QuestionTextBox.Text.Length <= 5)
            {
                ErrorLabel.Text = "Question too short, please add a valid question";
                return;
            }
            if (AnswerTextBox.Text.Length <= 5)
            {
                ErrorLabel.Text = "Answer too short, please add a valid question";
                return;
            }
            if (!SetAsChildradioButton.Checked && !SetAsParentradioButton.Checked && !NewNodeRadioButton.Checked)
            {
                ErrorLabel.Text = "You must select one of the radio buttons";
                return;
            }
            if (!QuestionTextBox.Text.Contains("?"))
                QuestionTextBox.Text += "?";
            temp.question = QuestionTextBox.Text;
            temp.answer = AnswerTextBox.Text;
            //Add new ID to child or parent lists
            if (SetAsChildradioButton.Checked)
            {
                //currentNode.children.Add(id);
            }
            if (SetAsParentradioButton.Checked)
            {
                //currentNode.parents.Add(id);
            }
            temp.intent = IntentTextBox.Text;
            //Submit new node to DB;

            QuestionTextBox.Clear();
            IntentTextBox.Clear();
            AnswerTextBox.Clear();
            ErrorLabel.Text = "";
        }
    }
}
