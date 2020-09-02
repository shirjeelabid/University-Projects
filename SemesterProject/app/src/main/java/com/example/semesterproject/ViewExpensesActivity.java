package com.example.semesterproject;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

import static java.security.AccessController.getContext;

public class ViewExpensesActivity extends AppCompatActivity {
    DatabaseHelper mydb = new DatabaseHelper(this);
    CustomAdapter adapter;
    ArrayList<String> Text;
    ListView listdata;
    Button refresh;
    int id;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_expenses);

        Intent intent = getIntent();
        id=intent.getIntExtra("id",-1);

        Text = new ArrayList<>();
        listdata = findViewById(R.id.list);
        refresh = findViewById(R.id.btnRefresh);
        refresh.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                viewData();
            }
        });

        viewData();


    }

    private void viewData(){

        ArrayList<Expense> list = new ArrayList<>();

        Cursor cursor = mydb.viewData(id);
        if(cursor.getCount()==0){
            Toast.makeText(this,"No data to show",Toast.LENGTH_LONG).show();
        }
        else{
            while(cursor.moveToNext()){

                Expense expense = new Expense(cursor.getInt(0),cursor.getInt(cursor.getColumnIndex("Amount")),cursor.getString(3),cursor.getString(cursor.getColumnIndex("Date")));

                list.add(expense);

            }
        }
        adapter = new CustomAdapter(this,0,list);
        listdata.setAdapter(adapter);
    }

}
