#include <iostream>
#include <string>
#include <msclr\marshal_cppstd.h>
#include "Source.h"
using namespace std;

#pragma once

namespace DictionaryDataStructures {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	Tries tree;
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
	private: System::Windows::Forms::ComboBox^  CBWord;
	protected:

	protected:


	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::RichTextBox^  RTBMeaning;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Button^  BTNSearch;
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
			this->CBWord = (gcnew System::Windows::Forms::ComboBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->BTNSearch = (gcnew System::Windows::Forms::Button());
			this->RTBMeaning = (gcnew System::Windows::Forms::RichTextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->panel1->SuspendLayout();
			this->SuspendLayout();
			// 
			// CBWord
			// 
			this->CBWord->AutoCompleteMode = System::Windows::Forms::AutoCompleteMode::Suggest;
			this->CBWord->AutoCompleteSource = System::Windows::Forms::AutoCompleteSource::ListItems;
			this->CBWord->Font = (gcnew System::Drawing::Font(L"Calibri", 12.096F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->CBWord->FormattingEnabled = true;
			this->CBWord->Location = System::Drawing::Point(244, 88);
			this->CBWord->Name = L"CBWord";
			this->CBWord->Size = System::Drawing::Size(303, 34);
			this->CBWord->Sorted = true;
			this->CBWord->TabIndex = 1;
			this->CBWord->TextUpdate += gcnew System::EventHandler(this, &MyForm::comboBox1_TextUpdate);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Calibri", 16.128F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(28, 84);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(150, 36);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Enter Word";
			// 
			// panel1
			// 
			this->panel1->BackColor = System::Drawing::Color::Cornsilk;
			this->panel1->Controls->Add(this->BTNSearch);
			this->panel1->Controls->Add(this->RTBMeaning);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Controls->Add(this->CBWord);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(855, 480);
			this->panel1->TabIndex = 3;
			// 
			// BTNSearch
			// 
			this->BTNSearch->BackColor = System::Drawing::Color::DarkOrange;
			this->BTNSearch->Font = (gcnew System::Drawing::Font(L"Calibri", 12.096F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTNSearch->Location = System::Drawing::Point(646, 88);
			this->BTNSearch->Name = L"BTNSearch";
			this->BTNSearch->Size = System::Drawing::Size(104, 43);
			this->BTNSearch->TabIndex = 2;
			this->BTNSearch->Text = L"Search";
			this->BTNSearch->UseVisualStyleBackColor = false;
			this->BTNSearch->Click += gcnew System::EventHandler(this, &MyForm::BTNSearch_Click);
			// 
			// RTBMeaning
			// 
			this->RTBMeaning->BackColor = System::Drawing::SystemColors::ControlLightLight;
			this->RTBMeaning->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->RTBMeaning->Font = (gcnew System::Drawing::Font(L"Calisto MT", 16.128F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->RTBMeaning->Location = System::Drawing::Point(34, 202);
			this->RTBMeaning->Name = L"RTBMeaning";
			this->RTBMeaning->ReadOnly = true;
			this->RTBMeaning->Size = System::Drawing::Size(686, 174);
			this->RTBMeaning->TabIndex = 3;
			this->RTBMeaning->TabStop = false;
			this->RTBMeaning->Text = L"";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Calibri", 16.128F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label2->Location = System::Drawing::Point(28, 148);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(134, 36);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Meaning: ";
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(855, 480);
			this->Controls->Add(this->panel1);
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void MyForm_Load(System::Object^  sender, System::EventArgs^  e) {
		tree.insert("Cat", "a small domesticated carnivorous mammal with soft fur, a short snout, and retractile claws. It is widely kept as a pet or for catching mice, and many breeds have been developed.");
		tree.insert("card", "a piece of thick, stiff paper or thin pasteboard, in particular one used for writing or printing on");
		tree.insert("can", "have the opportunity or possibility to.");
		tree.insert("call","a cry made as a summons or to attract someone's attention.");
		tree.insert("abcd");
		tree.insert("abchhgg");
	}
	private: System::Void comboBox1_TextUpdate(System::Object^  sender, System::EventArgs^  e) {
		msclr::interop::marshal_context context;
		string n = context.marshal_as<string>(CBWord->Text);
		tree.suggestions(n, this->CBWord);
	}
	private: System::Void BTNSearch_Click(System::Object^  sender, System::EventArgs^  e) {
		msclr::interop::marshal_context context;
		string n = context.marshal_as<string>(CBWord->Text);
		n = tree.search(n);
		if (n != " ")
		{
			RTBMeaning->Text = gcnew String(n.c_str());
		}
	}
};
}