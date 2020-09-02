package com.example.semesterproject;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import static android.widget.Toast.LENGTH_LONG;
import static android.widget.Toast.makeText;

public class SignupActivity extends AppCompatActivity {
    DatabaseHelper mydb;
    Button btn1;
    EditText edt1,edt2,edt3;
    String EMAIL,PWD,C_pWD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_signup);
        mydb=new DatabaseHelper(this);
        //////SignUp/////
        edt1=(EditText)findViewById(R.id.EmailSignup);
        edt2=(EditText)findViewById(R.id.PswdSignup);
        edt3=(EditText)findViewById(R.id.ConfirmPswdSignup);
        btn1=(Button)findViewById(R.id.btnCreateAcc);

        btn1.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EMAIL=String.valueOf(edt1.getText());
                PWD=String.valueOf(edt2.getText());
                C_pWD=String.valueOf(edt3.getText());

                if(PWD.equals(C_pWD) && !(EMAIL.equals(""))){
                   if(insert_data(EMAIL,PWD)){
                    int id = getID(EMAIL);
                    main_page(id);
                    makeText(getApplicationContext(), "Welcome", LENGTH_LONG).show();}
                }
                else{
                    makeText(getApplicationContext(), "Invalid Credentials!!", LENGTH_LONG).show();
                }

            }
        });

    }

   public void main_page(int Pid)
   {
        Intent intent=new Intent(SignupActivity.this, MainMenu.class);
        intent.putExtra("id",Pid);
        startActivity(intent);
        finish();
   }


    public boolean insert_data(String email, String pword) {

        if(!duplicate_Email(email)){
        SQLiteDatabase db = mydb.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(DBContractClass.FeedPerson.Col1, email);
        contentValues.put(DBContractClass.FeedPerson.Col2, pword);
        

        long result = db.insert(DBContractClass.FeedPerson.TABLE_NAME, null, contentValues);


        if (result == -1) {
            return false;
        } else {
            return true;
        }
        }

        else{Toast.makeText(getApplicationContext(),"This Email is already Registered!", Toast.LENGTH_SHORT).show();return false;}

    }

    public boolean duplicate_Email(String Email)
    {
        SQLiteDatabase db = mydb.getReadableDatabase();
        String query = "Select * From Person Where Email = ?";
        String[] columns = {"_ID"};
        Cursor cursor= db.query("Person",null,"Email = ?",new String[]{Email},null,null,null);

        if(cursor.getCount()>0)
            return true;

        return false;
    }

    public int getID(String Email)
    {

        SQLiteDatabase db = mydb.getReadableDatabase();
        int id=0;

        String query = "Select ID From Person Where Email = ?";
        String[] columns = {"_ID"};
        Cursor cursor= db.query("Person",columns,"Email = ?",new String[]{Email},null,null,null);

        if(cursor.getCount()>0)
           cursor.moveToFirst();
        id = cursor.getInt(0);

        return id;
    }
}
