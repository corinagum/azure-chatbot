namespace GUIforDB
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.IDradioButton = new System.Windows.Forms.RadioButton();
            this.ParentIDradioButton = new System.Windows.Forms.RadioButton();
            this.ChildIDradioButton = new System.Windows.Forms.RadioButton();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ResultsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.QuestionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.IntentTextBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AnswerEditTextBox = new System.Windows.Forms.TextBox();
            this.CurrentNodeAnswer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ConventionTextBox = new System.Windows.Forms.TextBox();
            this.ChildrenEditTextBox = new System.Windows.Forms.TextBox();
            this.ParentsEditTextBox = new System.Windows.Forms.TextBox();
            this.QuestionEditTextBox = new System.Windows.Forms.TextBox();
            this.IDeditTextBox = new System.Windows.Forms.TextBox();
            this.CurrentNodeQuestion = new System.Windows.Forms.Label();
            this.CurrentNodeParents = new System.Windows.Forms.Label();
            this.CurrentNodeChildren = new System.Windows.Forms.Label();
            this.CurrentNodeID = new System.Windows.Forms.Label();
            this.SetAsChildradioButton = new System.Windows.Forms.RadioButton();
            this.SetAsParentradioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.SubmitEditButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.AnswerTextBox = new System.Windows.Forms.TextBox();
            this.NewNodeRadioButton = new System.Windows.Forms.RadioButton();
            this.QuestionRadioButton = new System.Windows.Forms.RadioButton();
            this.SearchErrorLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Azure Support Chatbot Database Entry Tool";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Node:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Search for node by:";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(165, 85);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(343, 22);
            this.SearchTextBox.TabIndex = 5;
            // 
            // IDradioButton
            // 
            this.IDradioButton.AutoSize = true;
            this.IDradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDradioButton.Location = new System.Drawing.Point(164, 55);
            this.IDradioButton.Name = "IDradioButton";
            this.IDradioButton.Size = new System.Drawing.Size(42, 21);
            this.IDradioButton.TabIndex = 7;
            this.IDradioButton.TabStop = true;
            this.IDradioButton.Text = "ID";
            this.IDradioButton.UseVisualStyleBackColor = true;
            // 
            // ParentIDradioButton
            // 
            this.ParentIDradioButton.AutoSize = true;
            this.ParentIDradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParentIDradioButton.Location = new System.Drawing.Point(295, 55);
            this.ParentIDradioButton.Name = "ParentIDradioButton";
            this.ParentIDradioButton.Size = new System.Drawing.Size(88, 21);
            this.ParentIDradioButton.TabIndex = 8;
            this.ParentIDradioButton.TabStop = true;
            this.ParentIDradioButton.Text = "Parent ID";
            this.ParentIDradioButton.UseVisualStyleBackColor = true;
            // 
            // ChildIDradioButton
            // 
            this.ChildIDradioButton.AutoSize = true;
            this.ChildIDradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChildIDradioButton.Location = new System.Drawing.Point(212, 55);
            this.ChildIDradioButton.Name = "ChildIDradioButton";
            this.ChildIDradioButton.Size = new System.Drawing.Size(77, 21);
            this.ChildIDradioButton.TabIndex = 9;
            this.ChildIDradioButton.TabStop = true;
            this.ChildIDradioButton.Text = "Child ID";
            this.ChildIDradioButton.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(433, 113);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ResultsListBox
            // 
            this.ResultsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsListBox.FormattingEnabled = true;
            this.ResultsListBox.HorizontalScrollbar = true;
            this.ResultsListBox.ItemHeight = 16;
            this.ResultsListBox.Location = new System.Drawing.Point(165, 145);
            this.ResultsListBox.MultiColumn = true;
            this.ResultsListBox.Name = "ResultsListBox";
            this.ResultsListBox.Size = new System.Drawing.Size(343, 148);
            this.ResultsListBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(100, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Results:";
            // 
            // SelectButton
            // 
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectButton.Location = new System.Drawing.Point(433, 299);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 14;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.Location = new System.Drawing.Point(169, 593);
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.Size = new System.Drawing.Size(339, 22);
            this.QuestionTextBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(207, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Insert Node";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(90, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Question:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(108, 678);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Intent:";
            // 
            // IntentTextBox
            // 
            this.IntentTextBox.Location = new System.Drawing.Point(169, 676);
            this.IntentTextBox.Name = "IntentTextBox";
            this.IntentTextBox.Size = new System.Drawing.Size(339, 22);
            this.IntentTextBox.TabIndex = 26;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(435, 704);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 32;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 39;
            this.label11.Text = "Question";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 40;
            this.label12.Text = "Parent(s)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 41;
            this.label13.Text = "Children";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.AnswerEditTextBox);
            this.panel1.Controls.Add(this.CurrentNodeAnswer);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ConventionTextBox);
            this.panel1.Controls.Add(this.ChildrenEditTextBox);
            this.panel1.Controls.Add(this.ParentsEditTextBox);
            this.panel1.Controls.Add(this.QuestionEditTextBox);
            this.panel1.Controls.Add(this.IDeditTextBox);
            this.panel1.Controls.Add(this.CurrentNodeQuestion);
            this.panel1.Controls.Add(this.CurrentNodeParents);
            this.panel1.Controls.Add(this.CurrentNodeChildren);
            this.panel1.Controls.Add(this.CurrentNodeID);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(166, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 197);
            this.panel1.TabIndex = 42;
            // 
            // AnswerEditTextBox
            // 
            this.AnswerEditTextBox.Location = new System.Drawing.Point(104, 66);
            this.AnswerEditTextBox.Name = "AnswerEditTextBox";
            this.AnswerEditTextBox.Size = new System.Drawing.Size(233, 22);
            this.AnswerEditTextBox.TabIndex = 52;
            this.AnswerEditTextBox.Visible = false;
            // 
            // CurrentNodeAnswer
            // 
            this.CurrentNodeAnswer.AutoSize = true;
            this.CurrentNodeAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentNodeAnswer.Location = new System.Drawing.Point(104, 68);
            this.CurrentNodeAnswer.Name = "CurrentNodeAnswer";
            this.CurrentNodeAnswer.Size = new System.Drawing.Size(0, 17);
            this.CurrentNodeAnswer.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "Answer";
            // 
            // ConventionTextBox
            // 
            this.ConventionTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.ConventionTextBox.Location = new System.Drawing.Point(103, 151);
            this.ConventionTextBox.Multiline = true;
            this.ConventionTextBox.Name = "ConventionTextBox";
            this.ConventionTextBox.ReadOnly = true;
            this.ConventionTextBox.Size = new System.Drawing.Size(234, 43);
            this.ConventionTextBox.TabIndex = 50;
            this.ConventionTextBox.Text = "Please follow the labeling convention of each text box when editing";
            this.ConventionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConventionTextBox.Visible = false;
            // 
            // ChildrenEditTextBox
            // 
            this.ChildrenEditTextBox.Location = new System.Drawing.Point(104, 123);
            this.ChildrenEditTextBox.Name = "ChildrenEditTextBox";
            this.ChildrenEditTextBox.Size = new System.Drawing.Size(233, 22);
            this.ChildrenEditTextBox.TabIndex = 49;
            this.ChildrenEditTextBox.Visible = false;
            // 
            // ParentsEditTextBox
            // 
            this.ParentsEditTextBox.Location = new System.Drawing.Point(104, 95);
            this.ParentsEditTextBox.Name = "ParentsEditTextBox";
            this.ParentsEditTextBox.Size = new System.Drawing.Size(233, 22);
            this.ParentsEditTextBox.TabIndex = 48;
            this.ParentsEditTextBox.Visible = false;
            // 
            // QuestionEditTextBox
            // 
            this.QuestionEditTextBox.Location = new System.Drawing.Point(104, 38);
            this.QuestionEditTextBox.Name = "QuestionEditTextBox";
            this.QuestionEditTextBox.Size = new System.Drawing.Size(233, 22);
            this.QuestionEditTextBox.TabIndex = 47;
            this.QuestionEditTextBox.Visible = false;
            // 
            // IDeditTextBox
            // 
            this.IDeditTextBox.Location = new System.Drawing.Point(104, 11);
            this.IDeditTextBox.Name = "IDeditTextBox";
            this.IDeditTextBox.ReadOnly = true;
            this.IDeditTextBox.Size = new System.Drawing.Size(100, 22);
            this.IDeditTextBox.TabIndex = 46;
            this.IDeditTextBox.Visible = false;
            // 
            // CurrentNodeQuestion
            // 
            this.CurrentNodeQuestion.AutoSize = true;
            this.CurrentNodeQuestion.Location = new System.Drawing.Point(101, 41);
            this.CurrentNodeQuestion.Name = "CurrentNodeQuestion";
            this.CurrentNodeQuestion.Size = new System.Drawing.Size(0, 17);
            this.CurrentNodeQuestion.TabIndex = 45;
            // 
            // CurrentNodeParents
            // 
            this.CurrentNodeParents.AutoSize = true;
            this.CurrentNodeParents.Location = new System.Drawing.Point(104, 98);
            this.CurrentNodeParents.Name = "CurrentNodeParents";
            this.CurrentNodeParents.Size = new System.Drawing.Size(0, 17);
            this.CurrentNodeParents.TabIndex = 44;
            // 
            // CurrentNodeChildren
            // 
            this.CurrentNodeChildren.AutoSize = true;
            this.CurrentNodeChildren.Location = new System.Drawing.Point(101, 121);
            this.CurrentNodeChildren.Name = "CurrentNodeChildren";
            this.CurrentNodeChildren.Size = new System.Drawing.Size(0, 17);
            this.CurrentNodeChildren.TabIndex = 43;
            // 
            // CurrentNodeID
            // 
            this.CurrentNodeID.AutoSize = true;
            this.CurrentNodeID.Location = new System.Drawing.Point(101, 14);
            this.CurrentNodeID.Name = "CurrentNodeID";
            this.CurrentNodeID.Size = new System.Drawing.Size(0, 17);
            this.CurrentNodeID.TabIndex = 42;
            // 
            // SetAsChildradioButton
            // 
            this.SetAsChildradioButton.AutoSize = true;
            this.SetAsChildradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetAsChildradioButton.Location = new System.Drawing.Point(171, 646);
            this.SetAsChildradioButton.Name = "SetAsChildradioButton";
            this.SetAsChildradioButton.Size = new System.Drawing.Size(60, 21);
            this.SetAsChildradioButton.TabIndex = 45;
            this.SetAsChildradioButton.TabStop = true;
            this.SetAsChildradioButton.Text = "Child";
            this.SetAsChildradioButton.UseVisualStyleBackColor = true;
            // 
            // SetAsParentradioButton
            // 
            this.SetAsParentradioButton.AutoSize = true;
            this.SetAsParentradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetAsParentradioButton.Location = new System.Drawing.Point(237, 646);
            this.SetAsParentradioButton.Name = "SetAsParentradioButton";
            this.SetAsParentradioButton.Size = new System.Drawing.Size(71, 21);
            this.SetAsParentradioButton.TabIndex = 44;
            this.SetAsParentradioButton.TabStop = true;
            this.SetAsParentradioButton.Text = "Parent";
            this.SetAsParentradioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(103, 648);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "Set as:";
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(74, 354);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(53, 23);
            this.EditButton.TabIndex = 46;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SubmitEditButton
            // 
            this.SubmitEditButton.Location = new System.Drawing.Point(436, 537);
            this.SubmitEditButton.Name = "SubmitEditButton";
            this.SubmitEditButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitEditButton.TabIndex = 47;
            this.SubmitEditButton.Text = "Submit";
            this.SubmitEditButton.UseVisualStyleBackColor = true;
            this.SubmitEditButton.Visible = false;
            this.SubmitEditButton.Click += new System.EventHandler(this.SubmitEditButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(167, 569);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 17);
            this.ErrorLabel.TabIndex = 48;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.answerLabel.Location = new System.Drawing.Point(97, 623);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(58, 17);
            this.answerLabel.TabIndex = 50;
            this.answerLabel.Text = "Answer:";
            // 
            // AnswerTextBox
            // 
            this.AnswerTextBox.Location = new System.Drawing.Point(169, 621);
            this.AnswerTextBox.Name = "AnswerTextBox";
            this.AnswerTextBox.Size = new System.Drawing.Size(339, 22);
            this.AnswerTextBox.TabIndex = 49;
            // 
            // NewNodeRadioButton
            // 
            this.NewNodeRadioButton.AutoSize = true;
            this.NewNodeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewNodeRadioButton.Location = new System.Drawing.Point(314, 646);
            this.NewNodeRadioButton.Name = "NewNodeRadioButton";
            this.NewNodeRadioButton.Size = new System.Drawing.Size(94, 21);
            this.NewNodeRadioButton.TabIndex = 51;
            this.NewNodeRadioButton.TabStop = true;
            this.NewNodeRadioButton.Text = "New Node";
            this.NewNodeRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuestionRadioButton
            // 
            this.QuestionRadioButton.AutoSize = true;
            this.QuestionRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionRadioButton.Location = new System.Drawing.Point(389, 55);
            this.QuestionRadioButton.Name = "QuestionRadioButton";
            this.QuestionRadioButton.Size = new System.Drawing.Size(86, 21);
            this.QuestionRadioButton.TabIndex = 52;
            this.QuestionRadioButton.TabStop = true;
            this.QuestionRadioButton.Text = "Question";
            this.QuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // SearchErrorLabel
            // 
            this.SearchErrorLabel.AutoSize = true;
            this.SearchErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchErrorLabel.Location = new System.Drawing.Point(162, 35);
            this.SearchErrorLabel.Name = "SearchErrorLabel";
            this.SearchErrorLabel.Size = new System.Drawing.Size(0, 17);
            this.SearchErrorLabel.TabIndex = 53;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 740);
            this.Controls.Add(this.SearchErrorLabel);
            this.Controls.Add(this.QuestionRadioButton);
            this.Controls.Add(this.NewNodeRadioButton);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.AnswerTextBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SubmitEditButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SetAsChildradioButton);
            this.Controls.Add(this.SetAsParentradioButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.IntentTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.QuestionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.ResultsListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ChildIDradioButton);
            this.Controls.Add(this.ParentIDradioButton);
            this.Controls.Add(this.IDradioButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Azure Support Chatbot Database Entry Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.RadioButton IDradioButton;
        private System.Windows.Forms.RadioButton ParentIDradioButton;
        private System.Windows.Forms.RadioButton ChildIDradioButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox ResultsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.TextBox QuestionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox IntentTextBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CurrentNodeID;
        private System.Windows.Forms.Label CurrentNodeQuestion;
        private System.Windows.Forms.Label CurrentNodeParents;
        private System.Windows.Forms.Label CurrentNodeChildren;
        private System.Windows.Forms.RadioButton SetAsChildradioButton;
        private System.Windows.Forms.RadioButton SetAsParentradioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ChildrenEditTextBox;
        private System.Windows.Forms.TextBox ParentsEditTextBox;
        private System.Windows.Forms.TextBox QuestionEditTextBox;
        private System.Windows.Forms.TextBox IDeditTextBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SubmitEditButton;
        private System.Windows.Forms.TextBox ConventionTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TextBox AnswerTextBox;
        private System.Windows.Forms.RadioButton NewNodeRadioButton;
        private System.Windows.Forms.RadioButton QuestionRadioButton;
        private System.Windows.Forms.Label CurrentNodeAnswer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AnswerEditTextBox;
        private System.Windows.Forms.Label SearchErrorLabel;
    }
}

