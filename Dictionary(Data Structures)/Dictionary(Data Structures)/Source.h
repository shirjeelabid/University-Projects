#include <iostream>
#include <string>
#include <msclr\marshal_cppstd.h>
using namespace std;
const int size = 26;
class Tries
{
	struct Node
	{
		struct Node* child[size];
		string msg;
		bool EndOfWord = false;
	};
public:
	Node *root;
	Tries()
	{
		root = getNode();
		root->EndOfWord = false;
	}
	Node* getNode()
	{
		Node *ptr = new Node();
		for (int i = 0; i < size; i++)
			ptr->child[i] = NULL;
		return ptr;
	}
	void insert(string word, string msg = " ")
	{
		Node *ptr = root;
		int alphabet;
		for (int i = 0; i < word.length(); i++)
		{
			word[i] = tolower(word.at(i));
			alphabet = int(word[i]) - int('a');
			if (ptr->child[alphabet] == NULL)
				ptr->child[alphabet] = getNode();
			ptr = ptr->child[alphabet];
		}
		ptr->EndOfWord = true;
		ptr->msg = msg;
	}
	string search(string word)
	{
		Node *ptr = root;
		int alphabet;

		for (int i = 0; i < word.length(); i++)
		{
			alphabet = int(word[i]) - int('a');
			if (ptr->child[alphabet] == NULL)
				return " ";
			ptr = ptr->child[alphabet];
		}
		return ptr->msg;
		//return ptr->EndOfWord;
	}
	bool islast(Node *ptr)
	{
		for (int i = 0; i < size; i++)
			if (ptr->child[i] != NULL)
				return false;
		return true;
	}
	bool suggestions(string word , System::Windows::Forms::ComboBox^ textBox)
	{
		Node *ptr = root;
		int alphabet;
		for (int i = 0; i < word.length(); i++)
		{
			alphabet = int(word[i]) - int('a');

			// no string in the Trie has this prefix 
			if (!ptr->child[alphabet])
				return false;

			ptr = ptr->child[alphabet];
		}
		bool last = islast(ptr);
		if (ptr->EndOfWord &&last)
		{
			cout << word << endl;
			return -1;
		}

		// If there are are nodes below last 
		// matching character. 
		if (!last)
		{
			string prefix = word;
			suggestionsRec(ptr, prefix, prefix, textBox);
			return 1;
		}
	}
	void suggestionsRec(Node* ptr, string prefix, string temp, System::Windows::Forms::ComboBox^ textBox)
	{
		// found a string in Trie with the given prefix 
		if (ptr->EndOfWord)
		{
			textBox->Items->Add(gcnew System::String(prefix.c_str()));
			cout << prefix<<endl;
		}
		for (int i = 0; i < size; i++)
		{
			temp = prefix;
			if (ptr->child[i])
			{
				// append current character to prefix string 
				prefix.push_back(97 + i);
				/*cout << char(97 + i);*/

				// recur over the rest 
				suggestionsRec(ptr->child[i], prefix, temp, textBox);
				prefix = temp;
			}
		}
		/*prefix = temp;*/
	}

};