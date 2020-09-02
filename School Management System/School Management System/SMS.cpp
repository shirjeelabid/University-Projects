#include <iostream>
#include <string>
#include <fstream>
using namespace std;
#include "SMS.h"
Admin::Admin()
{
	email = "Admin@gmail.com";
	password = "123456";
}
bool Admin::checkpassword(string name, string pass)
{
	if (email == name&&password == pass)
		return true;
	else
		return false;
}
void Admin::AddNewStudent(Student &student, string first, string last, string email, string date, string Contactno, string pass, string Address, char g, string Class, string fathername, string mothername, string f_prof, string m_prof, string dob, string contact, string BloodGroup, int Fees)
{
	string data;
	int index = 0;
	student.f_name = first;
	student.l_name = last;
	student.email = email;
	student.reg_Date = date;
	student.password = pass;
	student.address = Address;
	student.gender = g;
	student.contactNo = Contactno;
	student.class_grade = Class;
	student.father = fathername;
	student.mother = mothername;
	student.father_prof = f_prof;
	student.mother_prof = m_prof;
	student.parent_contactNo = contact;
	student.bloodGrp = BloodGroup;
	student.fees = Fees;
	student.DOB = dob;
	ifstream indata("Students.txt");
	while (getline(indata, data))
		index++;
	indata.close();
	student.rollNo = 1000 + index;
	ofstream outdata("Students.txt", ios::app);
	outdata << student.rollNo << "<" << student.f_name << "<" << student.l_name << "<" << student.email << "<" << student.password << "<" << student.DOB << "<" << student.reg_Date << "<" << student.gender << "<" << student.contactNo << "<" << student.class_grade << "<" << student.father << "<" << student.mother << "<" << student.father_prof << "<" << student.mother_prof << "<" << student.parent_contactNo << "<" << student.address << "<" << student.bloodGrp << "<" << student.fees <<"<"<<endl;
	outdata.close();
}
void Admin::EditTeacherData(string n, string l)
{
	ofstream outdata("Students.txt");
	outdata << n << "<" << l << endl;
}