package com.example.semesterproject;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
Button btn2,signin;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn2=(Button)findViewById(R.id.btnSignUp);
        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                create_account();
            }
        });
        ///Login/////
        DatabaseHelper helper=new DatabaseHelper(getApplicationContext());
        final SQLiteDatabase db=helper.getReadableDatabase();

        signin=(Button)findViewById(R.id.btnLogin);
        signin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText username=(EditText)findViewById(R.id.EmailLogin);
                EditText password=(EditText)findViewById(R.id.Passlogin);

                String user=String.valueOf(username.getText());
                String pass=String.valueOf(password.getText());

                String sql = "select ID as id from Person where Email = '" + user + "' and Password = '" + pass + "' ;";
                Cursor cursor = db.rawQuery("SELECT _ID as id from Person WHERE Email = ? and Password = ?", new String[]{user, pass});

                int id;

                if(cursor!=null)
                {
                    if(cursor.moveToFirst()){
                        id=cursor.getInt(cursor.getColumnIndex("id"));
                        String ids=Integer.toString(id);
                        Intent intent=new Intent(MainActivity.this,MainMenu.class);
                        intent.putExtra("id",id);
                        intent.putExtra("user",user);
                        Toast.makeText(getApplicationContext(), "Welcome To Main Menu", Toast.LENGTH_LONG).show();
                        startActivity(intent);
                        finish();
                    }
                    else{
                        Toast.makeText(getApplicationContext(), "Login Failed!", Toast.LENGTH_SHORT).show();
                    }
                }
                else{
                    Toast.makeText(getApplicationContext(), "Login Failed!", Toast.LENGTH_SHORT).show();
                }

            }
        });


    }

    public void create_account(){
        Intent intent=new Intent(MainActivity.this, SignupActivity.class);
        startActivity(intent);
    }
}
