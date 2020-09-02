package com.example.semesterproject;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import static android.widget.Toast.LENGTH_LONG;
import static android.widget.Toast.makeText;

public class IncomeActivity extends AppCompatActivity {

    private int id;
    Button btn;
    String income;
    DatabaseHelper mydb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_income);

        Intent intent = getIntent();
        id=intent.getIntExtra("id",-1);
        mydb=new DatabaseHelper(this);

        btn=(Button)findViewById(R.id.add_income);


        final EditText edt1=(EditText)findViewById(R.id.get_amount);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                income=String.valueOf(edt1.getText());

                if(!(income.equals(""))){
                    insert_income(income,id);
                    makeText(getApplicationContext(), "Income Inserted", LENGTH_LONG).show();

                }else{
                    makeText(getApplicationContext(), "Invalid Entry!!", LENGTH_LONG).show();
                }

            }
        });

    }


    public boolean insert_income(String amount,int id){
        SQLiteDatabase db = mydb.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(DBContractClass.FeedIncome.C1, amount);
        contentValues.put(DBContractClass.FeedIncome.C2, id);




        long result = db.insert(DBContractClass.FeedIncome.TABLE_3, null, contentValues);

        if(result==-1){
            return false;
        }else{
            return true;
        }
    }//hogai
}
