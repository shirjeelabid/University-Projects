#include "MyForm.h"
#include <string.h>
using namespace SchoolManagementSystem;
[STAThreadAttribute]
void main()
{
	Application::Run(gcnew MyForm());          /*Form name*/ /*constructor calling of form*/
	return;
}
