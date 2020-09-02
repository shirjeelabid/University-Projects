#pragma once
#include "SMS.h"
#include <msclr\marshal_cppstd.h>
#include <string.h>
#include <fstream>
using namespace std;
namespace SchoolManagementSystem {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	/// <summary>
	/// Summary for MyForm
	/// </summary>
	Admin admin;
	Student student;
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Panel^  mainpanel;
	protected:

	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  adminbtn;



	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::TextBox^  textBox2;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;


	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::Button^  button4;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::Button^  button5;
	private: System::Windows::Forms::Button^  button6;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Panel^  panel3;
	private: System::Windows::Forms::TextBox^  email;

	private: System::Windows::Forms::TextBox^  lName;



	private: System::Windows::Forms::TextBox^  fName;

	private: System::Windows::Forms::ComboBox^  comboBox1;
	private: System::Windows::Forms::TextBox^  regdate;
	private: System::Windows::Forms::ComboBox^  gender;



	private: System::Windows::Forms::TextBox^  DOB;

	private: System::Windows::Forms::TextBox^  mother;
	private: System::Windows::Forms::TextBox^  parentNo;



	private: System::Windows::Forms::TextBox^  father;


	private: System::Windows::Forms::TextBox^  mobileNo;

	private: System::Windows::Forms::Button^  button8;
	private: System::Windows::Forms::Button^  button7;
	private: System::Windows::Forms::TextBox^  address;

	private: System::Windows::Forms::TextBox^  fees;
	private: System::Windows::Forms::TextBox^  password;
	private: System::Windows::Forms::TextBox^  mother_prof;

	private: System::Windows::Forms::TextBox^  father_prof;
	private: System::Windows::Forms::TextBox^  B_grp;
	private: System::Windows::Forms::Panel^  EditStudentPanel;

	private: System::Windows::Forms::TextBox^  edit_number;
	private: System::Windows::Forms::TextBox^  edit_address;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::ComboBox^  student_combobox;
	private: System::Windows::Forms::Button^  button9;
	private: System::Windows::Forms::Button^  submit_edit;
	private: System::Windows::Forms::Button^  cancel_edit;
	private: System::Windows::Forms::TextBox^  edit_fees;



	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->mainpanel = (gcnew System::Windows::Forms::Panel());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->adminbtn = (gcnew System::Windows::Forms::Button());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->button9 = (gcnew System::Windows::Forms::Button());
			this->button6 = (gcnew System::Windows::Forms::Button());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->panel3 = (gcnew System::Windows::Forms::Panel());
			this->B_grp = (gcnew System::Windows::Forms::TextBox());
			this->mother_prof = (gcnew System::Windows::Forms::TextBox());
			this->father_prof = (gcnew System::Windows::Forms::TextBox());
			this->button8 = (gcnew System::Windows::Forms::Button());
			this->button7 = (gcnew System::Windows::Forms::Button());
			this->gender = (gcnew System::Windows::Forms::ComboBox());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->email = (gcnew System::Windows::Forms::TextBox());
			this->lName = (gcnew System::Windows::Forms::TextBox());
			this->DOB = (gcnew System::Windows::Forms::TextBox());
			this->mother = (gcnew System::Windows::Forms::TextBox());
			this->password = (gcnew System::Windows::Forms::TextBox());
			this->address = (gcnew System::Windows::Forms::TextBox());
			this->fees = (gcnew System::Windows::Forms::TextBox());
			this->parentNo = (gcnew System::Windows::Forms::TextBox());
			this->father = (gcnew System::Windows::Forms::TextBox());
			this->mobileNo = (gcnew System::Windows::Forms::TextBox());
			this->regdate = (gcnew System::Windows::Forms::TextBox());
			this->fName = (gcnew System::Windows::Forms::TextBox());
			this->EditStudentPanel = (gcnew System::Windows::Forms::Panel());
			this->submit_edit = (gcnew System::Windows::Forms::Button());
			this->cancel_edit = (gcnew System::Windows::Forms::Button());
			this->edit_fees = (gcnew System::Windows::Forms::TextBox());
			this->edit_number = (gcnew System::Windows::Forms::TextBox());
			this->edit_address = (gcnew System::Windows::Forms::TextBox());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->student_combobox = (gcnew System::Windows::Forms::ComboBox());
			this->mainpanel->SuspendLayout();
			this->panel1->SuspendLayout();
			this->panel2->SuspendLayout();
			this->panel3->SuspendLayout();
			this->EditStudentPanel->SuspendLayout();
			this->SuspendLayout();
			// 
			// mainpanel
			// 
			this->mainpanel->Controls->Add(this->button4);
			this->mainpanel->Controls->Add(this->button3);
			this->mainpanel->Controls->Add(this->label1);
			this->mainpanel->Controls->Add(this->adminbtn);
			this->mainpanel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->mainpanel->Location = System::Drawing::Point(0, 0);
			this->mainpanel->Name = L"mainpanel";
			this->mainpanel->Size = System::Drawing::Size(1057, 441);
			this->mainpanel->TabIndex = 0;
			this->mainpanel->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::panel1_Paint);
			// 
			// button4
			// 
			this->button4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button4->Location = System::Drawing::Point(200, 238);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(110, 45);
			this->button4->TabIndex = 3;
			this->button4->Text = L"Student";
			this->button4->UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this->button3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button3->Location = System::Drawing::Point(200, 159);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(110, 48);
			this->button3->TabIndex = 2;
			this->button3->Text = L"Teacher";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm::button3_Click);
			// 
			// label1
			// 
			this->label1->Font = (gcnew System::Drawing::Font(L"Modern No. 20", 27.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(99, 21);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(591, 52);
			this->label1->TabIndex = 1;
			this->label1->Text = L"School Management System(SMS)";
			this->label1->Click += gcnew System::EventHandler(this, &MyForm::label1_Click);
			// 
			// adminbtn
			// 
			this->adminbtn->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->adminbtn->Location = System::Drawing::Point(200, 93);
			this->adminbtn->Name = L"adminbtn";
			this->adminbtn->Size = System::Drawing::Size(110, 46);
			this->adminbtn->TabIndex = 0;
			this->adminbtn->Text = L"Admin";
			this->adminbtn->UseVisualStyleBackColor = true;
			this->adminbtn->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->label4);
			this->panel1->Controls->Add(this->textBox2);
			this->panel1->Controls->Add(this->textBox1);
			this->panel1->Controls->Add(this->label5);
			this->panel1->Controls->Add(this->button2);
			this->panel1->Controls->Add(this->button1);
			this->panel1->Controls->Add(this->label3);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(1057, 441);
			this->panel1->TabIndex = 2;
			this->panel1->Visible = false;
			this->panel1->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::panel1_Paint_1);
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13.8F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label4->Location = System::Drawing::Point(133, 56);
			this->label4->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(307, 24);
			this->label4->TabIndex = 4;
			this->label4->Text = L"Invalid login username or password";
			this->label4->Visible = false;
			this->label4->Click += gcnew System::EventHandler(this, &MyForm::label4_Click);
			// 
			// textBox2
			// 
			this->textBox2->Location = System::Drawing::Point(182, 91);
			this->textBox2->Name = L"textBox2";
			this->textBox2->Size = System::Drawing::Size(206, 20);
			this->textBox2->TabIndex = 3;
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(182, 133);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(206, 20);
			this->textBox1->TabIndex = 3;
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label5->Location = System::Drawing::Point(48, 128);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(92, 24);
			this->label5->TabIndex = 1;
			this->label5->Text = L"Password";
			// 
			// button2
			// 
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button2->Location = System::Drawing::Point(71, 209);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(111, 49);
			this->button2->TabIndex = 2;
			this->button2->Text = L"Back";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::button2_Click);
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button1->Location = System::Drawing::Point(396, 209);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(111, 49);
			this->button1->TabIndex = 2;
			this->button1->Text = L"Log In";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click_1);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label3->Location = System::Drawing::Point(38, 86);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(113, 25);
			this->label3->TabIndex = 1;
			this->label3->Text = L"UserName";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Modern No. 20", 27.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label2->Location = System::Drawing::Point(262, 21);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(126, 38);
			this->label2->TabIndex = 0;
			this->label2->Text = L"Admin";
			// 
			// panel2
			// 
			this->panel2->Controls->Add(this->button9);
			this->panel2->Controls->Add(this->button6);
			this->panel2->Controls->Add(this->button5);
			this->panel2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel2->Location = System::Drawing::Point(0, 0);
			this->panel2->Margin = System::Windows::Forms::Padding(2);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(1057, 441);
			this->panel2->TabIndex = 3;
			this->panel2->Visible = false;
			// 
			// button9
			// 
			this->button9->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button9->Location = System::Drawing::Point(34, 85);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(206, 46);
			this->button9->TabIndex = 3;
			this->button9->Text = L"Edit Student Data";
			this->button9->UseVisualStyleBackColor = true;
			this->button9->Click += gcnew System::EventHandler(this, &MyForm::button9_Click);
			// 
			// button6
			// 
			this->button6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16.2F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button6->Location = System::Drawing::Point(34, 197);
			this->button6->Margin = System::Windows::Forms::Padding(2);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(112, 54);
			this->button6->TabIndex = 1;
			this->button6->Text = L"Back";
			this->button6->UseVisualStyleBackColor = true;
			this->button6->Click += gcnew System::EventHandler(this, &MyForm::button6_Click_1);
			// 
			// button5
			// 
			this->button5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16.2F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button5->Location = System::Drawing::Point(34, 22);
			this->button5->Margin = System::Windows::Forms::Padding(2);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(206, 47);
			this->button5->TabIndex = 0;
			this->button5->Text = L"Add Student";
			this->button5->UseVisualStyleBackColor = true;
			this->button5->Click += gcnew System::EventHandler(this, &MyForm::button5_Click);
			// 
			// panel3
			// 
			this->panel3->Controls->Add(this->B_grp);
			this->panel3->Controls->Add(this->mother_prof);
			this->panel3->Controls->Add(this->father_prof);
			this->panel3->Controls->Add(this->button8);
			this->panel3->Controls->Add(this->button7);
			this->panel3->Controls->Add(this->gender);
			this->panel3->Controls->Add(this->comboBox1);
			this->panel3->Controls->Add(this->email);
			this->panel3->Controls->Add(this->lName);
			this->panel3->Controls->Add(this->DOB);
			this->panel3->Controls->Add(this->mother);
			this->panel3->Controls->Add(this->password);
			this->panel3->Controls->Add(this->address);
			this->panel3->Controls->Add(this->fees);
			this->panel3->Controls->Add(this->parentNo);
			this->panel3->Controls->Add(this->father);
			this->panel3->Controls->Add(this->mobileNo);
			this->panel3->Controls->Add(this->regdate);
			this->panel3->Controls->Add(this->fName);
			this->panel3->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel3->Location = System::Drawing::Point(0, 0);
			this->panel3->Name = L"panel3";
			this->panel3->Size = System::Drawing::Size(1057, 441);
			this->panel3->TabIndex = 2;
			this->panel3->Visible = false;
			this->panel3->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::panel3_Paint);
			// 
			// B_grp
			// 
			this->B_grp->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->B_grp->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->B_grp->Location = System::Drawing::Point(605, 100);
			this->B_grp->Name = L"B_grp";
			this->B_grp->Size = System::Drawing::Size(225, 33);
			this->B_grp->TabIndex = 4;
			this->B_grp->Text = L"Blood Group";
			// 
			// mother_prof
			// 
			this->mother_prof->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->mother_prof->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->mother_prof->Location = System::Drawing::Point(605, 61);
			this->mother_prof->Name = L"mother_prof";
			this->mother_prof->Size = System::Drawing::Size(225, 33);
			this->mother_prof->TabIndex = 4;
			this->mother_prof->Text = L"Mother Profession";
			// 
			// father_prof
			// 
			this->father_prof->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->father_prof->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->father_prof->Location = System::Drawing::Point(605, 21);
			this->father_prof->Name = L"father_prof";
			this->father_prof->Size = System::Drawing::Size(225, 33);
			this->father_prof->TabIndex = 4;
			this->father_prof->Text = L"Father Profession";
			// 
			// button8
			// 
			this->button8->Font = (gcnew System::Drawing::Font(L"MS Reference Sans Serif", 20.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button8->Location = System::Drawing::Point(190, 303);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(110, 39);
			this->button8->TabIndex = 3;
			this->button8->Text = L"Canel";
			this->button8->UseVisualStyleBackColor = true;
			this->button8->Click += gcnew System::EventHandler(this, &MyForm::button8_Click);
			// 
			// button7
			// 
			this->button7->Font = (gcnew System::Drawing::Font(L"MS Reference Sans Serif", 20.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->button7->Location = System::Drawing::Point(406, 303);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(122, 36);
			this->button7->TabIndex = 2;
			this->button7->Text = L"Submit";
			this->button7->UseVisualStyleBackColor = true;
			this->button7->Click += gcnew System::EventHandler(this, &MyForm::button7_Click);
			// 
			// gender
			// 
			this->gender->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->gender->FormattingEnabled = true;
			this->gender->Items->AddRange(gcnew cli::array< System::Object^  >(2) { L"M", L"F" });
			this->gender->Location = System::Drawing::Point(21, 138);
			this->gender->Name = L"gender";
			this->gender->Size = System::Drawing::Size(227, 34);
			this->gender->TabIndex = 1;
			this->gender->Text = L"Gender";
			this->gender->SelectedIndexChanged += gcnew System::EventHandler(this, &MyForm::comboBox1_SelectedIndexChanged);
			// 
			// comboBox1
			// 
			this->comboBox1->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Items->AddRange(gcnew cli::array< System::Object^  >(12) {
				L"Pre-Nursery", L"Prep", L"1", L"2", L"3", L"4",
					L"5", L"6", L"7", L"8", L"9", L"10"
			});
			this->comboBox1->Location = System::Drawing::Point(312, 98);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(266, 34);
			this->comboBox1->TabIndex = 1;
			this->comboBox1->Text = L"CLASS";
			this->comboBox1->SelectedIndexChanged += gcnew System::EventHandler(this, &MyForm::comboBox1_SelectedIndexChanged);
			// 
			// email
			// 
			this->email->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->email->Location = System::Drawing::Point(21, 60);
			this->email->Name = L"email";
			this->email->Size = System::Drawing::Size(227, 33);
			this->email->TabIndex = 0;
			this->email->Text = L"Email";
			// 
			// lName
			// 
			this->lName->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->lName->Location = System::Drawing::Point(312, 22);
			this->lName->Name = L"lName";
			this->lName->Size = System::Drawing::Size(266, 33);
			this->lName->TabIndex = 0;
			this->lName->Text = L"Last Name";
			this->lName->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox4_TextChanged);
			// 
			// DOB
			// 
			this->DOB->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->DOB->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->DOB->Location = System::Drawing::Point(312, 220);
			this->DOB->Name = L"DOB";
			this->DOB->Size = System::Drawing::Size(266, 33);
			this->DOB->TabIndex = 0;
			this->DOB->Text = L"Birth Date";
			// 
			// mother
			// 
			this->mother->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->mother->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->mother->Location = System::Drawing::Point(312, 181);
			this->mother->Name = L"mother";
			this->mother->Size = System::Drawing::Size(266, 33);
			this->mother->TabIndex = 0;
			this->mother->Text = L"Mother Name";
			// 
			// password
			// 
			this->password->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->password->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->password->Location = System::Drawing::Point(312, 61);
			this->password->Name = L"password";
			this->password->Size = System::Drawing::Size(266, 33);
			this->password->TabIndex = 0;
			this->password->Text = L"Password";
			this->password->TextChanged += gcnew System::EventHandler(this, &MyForm::password_TextChanged);
			// 
			// address
			// 
			this->address->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->address->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->address->Location = System::Drawing::Point(312, 259);
			this->address->Name = L"address";
			this->address->Size = System::Drawing::Size(266, 33);
			this->address->TabIndex = 0;
			this->address->Text = L"Address";
			// 
			// fees
			// 
			this->fees->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->fees->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->fees->Location = System::Drawing::Point(21, 256);
			this->fees->Name = L"fees";
			this->fees->Size = System::Drawing::Size(227, 33);
			this->fees->TabIndex = 0;
			this->fees->Text = L"Fees";
			// 
			// parentNo
			// 
			this->parentNo->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->parentNo->Location = System::Drawing::Point(21, 217);
			this->parentNo->Name = L"parentNo";
			this->parentNo->Size = System::Drawing::Size(227, 33);
			this->parentNo->TabIndex = 0;
			this->parentNo->Text = L"Parents Mobile Number";
			// 
			// father
			// 
			this->father->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->father->Location = System::Drawing::Point(21, 178);
			this->father->Name = L"father";
			this->father->Size = System::Drawing::Size(227, 33);
			this->father->TabIndex = 0;
			this->father->Text = L"Father Name\r\n";
			// 
			// mobileNo
			// 
			this->mobileNo->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->mobileNo->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->mobileNo->Location = System::Drawing::Point(312, 142);
			this->mobileNo->Name = L"mobileNo";
			this->mobileNo->Size = System::Drawing::Size(266, 33);
			this->mobileNo->TabIndex = 0;
			this->mobileNo->Text = L"Mobile Number";
			// 
			// regdate
			// 
			this->regdate->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->regdate->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->regdate->Location = System::Drawing::Point(21, 99);
			this->regdate->Name = L"regdate";
			this->regdate->Size = System::Drawing::Size(227, 33);
			this->regdate->TabIndex = 0;
			this->regdate->Text = L"Registration Date";
			// 
			// fName
			// 
			this->fName->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->fName->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->fName->Location = System::Drawing::Point(21, 21);
			this->fName->Name = L"fName";
			this->fName->Size = System::Drawing::Size(227, 33);
			this->fName->TabIndex = 0;
			this->fName->Text = L"First Name";
			this->fName->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox3_TextChanged);
			// 
			// EditStudentPanel
			// 
			this->EditStudentPanel->Controls->Add(this->submit_edit);
			this->EditStudentPanel->Controls->Add(this->cancel_edit);
			this->EditStudentPanel->Controls->Add(this->edit_fees);
			this->EditStudentPanel->Controls->Add(this->edit_number);
			this->EditStudentPanel->Controls->Add(this->edit_address);
			this->EditStudentPanel->Controls->Add(this->label6);
			this->EditStudentPanel->Controls->Add(this->student_combobox);
			this->EditStudentPanel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->EditStudentPanel->Location = System::Drawing::Point(0, 0);
			this->EditStudentPanel->Name = L"EditStudentPanel";
			this->EditStudentPanel->Size = System::Drawing::Size(1057, 441);
			this->EditStudentPanel->TabIndex = 3;
			this->EditStudentPanel->Visible = false;
			this->EditStudentPanel->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::EditStudentPanel_Paint);
			// 
			// submit_edit
			// 
			this->submit_edit->Font = (gcnew System::Drawing::Font(L"Calibri", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->submit_edit->Location = System::Drawing::Point(512, 279);
			this->submit_edit->Name = L"submit_edit";
			this->submit_edit->Size = System::Drawing::Size(115, 38);
			this->submit_edit->TabIndex = 5;
			this->submit_edit->Text = L"Submit";
			this->submit_edit->UseVisualStyleBackColor = true;
			this->submit_edit->Click += gcnew System::EventHandler(this, &MyForm::submit_edit_Click);
			// 
			// cancel_edit
			// 
			this->cancel_edit->Font = (gcnew System::Drawing::Font(L"Calibri", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->cancel_edit->Location = System::Drawing::Point(151, 279);
			this->cancel_edit->Name = L"cancel_edit";
			this->cancel_edit->Size = System::Drawing::Size(111, 38);
			this->cancel_edit->TabIndex = 4;
			this->cancel_edit->Text = L"Canel";
			this->cancel_edit->UseVisualStyleBackColor = true;
			this->cancel_edit->Click += gcnew System::EventHandler(this, &MyForm::cancel_edit_Click);
			// 
			// edit_fees
			// 
			this->edit_fees->Font = (gcnew System::Drawing::Font(L"Calibri", 15.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->edit_fees->Location = System::Drawing::Point(35, 207);
			this->edit_fees->Name = L"edit_fees";
			this->edit_fees->Size = System::Drawing::Size(356, 33);
			this->edit_fees->TabIndex = 3;
			this->edit_fees->Text = L"Fees";
			// 
			// edit_number
			// 
			this->edit_number->Font = (gcnew System::Drawing::Font(L"Calibri", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->edit_number->Location = System::Drawing::Point(35, 158);
			this->edit_number->Name = L"edit_number";
			this->edit_number->Size = System::Drawing::Size(356, 31);
			this->edit_number->TabIndex = 2;
			this->edit_number->Text = L"Mobile Number";
			// 
			// edit_address
			// 
			this->edit_address->Font = (gcnew System::Drawing::Font(L"Calibri", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->edit_address->Location = System::Drawing::Point(35, 111);
			this->edit_address->Name = L"edit_address";
			this->edit_address->Size = System::Drawing::Size(356, 31);
			this->edit_address->TabIndex = 2;
			this->edit_address->Text = L"Address";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Font = (gcnew System::Drawing::Font(L"MS Reference Sans Serif", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label6->Location = System::Drawing::Point(17, 22);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(149, 24);
			this->label6->TabIndex = 1;
			this->label6->Text = L"Select Student";
			// 
			// student_combobox
			// 
			this->student_combobox->FormattingEnabled = true;
			this->student_combobox->Location = System::Drawing::Point(208, 22);
			this->student_combobox->Name = L"student_combobox";
			this->student_combobox->Size = System::Drawing::Size(389, 21);
			this->student_combobox->TabIndex = 0;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1057, 441);
			this->Controls->Add(this->mainpanel);
			this->Controls->Add(this->panel1);
			this->Controls->Add(this->panel2);
			this->Controls->Add(this->panel3);
			this->Controls->Add(this->EditStudentPanel);
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->mainpanel->ResumeLayout(false);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->panel2->ResumeLayout(false);
			this->panel3->ResumeLayout(false);
			this->panel3->PerformLayout();
			this->EditStudentPanel->ResumeLayout(false);
			this->EditStudentPanel->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void panel1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
		mainpanel->Visible = false;
		panel1->Visible = true;
	}
	private: System::Void MyForm_Load(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void panel1_Paint_1(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
	}
	private: System::Void label1_Click(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void button6_Click(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
		panel1->Visible = false;
		mainpanel->Visible = true;
	}
	private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {

	}
	private: System::Void button1_Click_1(System::Object^  sender, System::EventArgs^  e) {
		msclr::interop::marshal_context context;
		string username = context.marshal_as<string>(textBox2->Text);
		string password = context.marshal_as<string>(textBox1->Text);
		if (admin.checkpassword(username, password))
		{
			panel1->Visible = false;
			label4->Visible = false;
			panel2->Visible = true;
		}
		else
			label4->Visible = true;
	}
	private: System::Void button5_Click(System::Object^  sender, System::EventArgs^  e) {
		panel2->Visible = false;
		panel3->Visible = true;
	}
	private: System::Void label4_Click(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void button6_Click_1(System::Object^  sender, System::EventArgs^  e) {
		panel2->Visible = false;
		panel1->Visible = true;
	}
	private: System::Void textBox3_TextChanged(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void textBox4_TextChanged(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void comboBox1_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void button8_Click(System::Object^  sender, System::EventArgs^  e) {
		panel3->Visible = false;
		panel2->Visible = true;
	}
	private: System::Void panel3_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
	}
	private: System::Void button7_Click(System::Object^  sender, System::EventArgs^  e) {
		string first, last, Email, date, Contactno, pass, Address, Class, fathername, mothername, f_prof, m_prof, parent_contact, BloodGroup, Birth;
		char g;
		int Fees;
		msclr::interop::marshal_context context;
		first = context.marshal_as<string>(fName->Text);
		last = context.marshal_as<string>(lName->Text);
		Email = context.marshal_as<string>(email->Text);
		date = context.marshal_as<string>(regdate->Text);
		pass = context.marshal_as<string>(password->Text);
		Address = context.marshal_as<string>(address->Text);
		fathername = context.marshal_as<string>(father->Text);
		mothername = context.marshal_as<string>(mother->Text);
		f_prof = context.marshal_as<string>(father_prof->Text);
		m_prof = context.marshal_as<string>(mother_prof->Text);
		Contactno = context.marshal_as<string>(mobileNo->Text);
		Birth = context.marshal_as<string>(DOB->Text);
		parent_contact = context.marshal_as<string>(parentNo->Text);
		Class = context.marshal_as<string>(comboBox1->Text);
		g = Convert::ToChar(gender->Text);
		Fees = Convert::ToInt32(fees->Text);
		BloodGroup = context.marshal_as<string>(B_grp->Text);
		admin.AddNewStudent(student, first, last, Email, date, Contactno, pass, Address, g, Class, fathername, mothername, f_prof, m_prof, parent_contact, Birth, BloodGroup, Fees);
		panel3->Visible = false;
		panel2->Visible = true;
	}
	private: System::Void password_TextChanged(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void EditStudentPanel_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
		string data;
		int index = 0;
		ifstream indata("Students.txt");
		while (getline(indata, data))
			index++;
		indata.close();
		string **arr = new string *[index];
		for (int i = 0; i < index; i++)
			arr[i] = new string[18];
		indata.open("Students.txt");
		int j = 0, k = 0;
		while (getline(indata, data, '<') && j < index)
		{
			arr[j][k] = data;
			if (k == 17)
			{
				j++;
				k = -1;
			}
			k++;
		}
		indata.close();
		j = 3;
		for (int i = 0; i < index; i++)
		{
		data = arr[i][j];
		student_combobox->Items->Add(gcnew String(data.c_str()));
		}
	}
	private: System::Void button9_Click(System::Object^  sender, System::EventArgs^  e) {
		panel2->Visible = false;
		EditStudentPanel->Visible = true;
	}
	private: System::Void cancel_edit_Click(System::Object^  sender, System::EventArgs^  e) {
		student_combobox->Items->Clear();
		EditStudentPanel->Visible = false;
		panel2->Visible = true;
	}
	private: System::Void submit_edit_Click(System::Object^  sender, System::EventArgs^  e) {
		/*Submit*/
		student_combobox->Items->Clear();
		EditStudentPanel->Visible = false;
		panel2->Visible = true;
	}
	};
}