#include <iostream>
#include <string>
using namespace std;
class Student;
class Person
{
public:
	string reg_Date, email, contactNo, password, address;
	string f_name, l_name;
	char gender;
};
class Admin :public Person
{
public:
	Admin();
	bool checkpassword(string, string);
	void AddNewStudent(Student &, string, string, string, string, string, string, string, char, string, string, string, string, string, string, string, string, int);
	void AssignCourse();
	void EditSudentData();
	void EditTeacherData(string, string);
	void ViewStudents(); bool ViewTeachers();
	bool ViewCourse();
	bool ViewStudentMarks();
	void ViewFeeStatus();


};
class Teacher :public Person
{
	string cnic, qualification[4];
	int Salary;
	void ViewCourses();
	void AddMAarks();
	void EditMarks();
};
class Student :public Person
{
public:
	int rollNo, fees;
	string class_grade, father, mother, father_prof, mother_prof, DOB, parent_contactNo, bloodGrp;
};
class Course
{
	int class_grade;
	string courseName, courseCode;

};