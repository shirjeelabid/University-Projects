package com.example.semesterproject;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Build;
import android.os.Bundle;
import android.text.InputType;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Calendar;

import static android.widget.Toast.LENGTH_LONG;
import static android.widget.Toast.makeText;

public class ExpensesActivity extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    String[] categories={"Fuel","Education","Food","Clothing","Bills","Misc"};
    DatePickerDialog picker;
    EditText eText;
    TextView tvw;
    DatabaseHelper mydb;
    String expense,date,items;
    Button btn;
    int id;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_expenses);
        mydb=new DatabaseHelper(this);

        Intent intent = getIntent();
        id=intent.getIntExtra("id",-1);

        Spinner spin=(Spinner)findViewById(R.id.spinner);
        spin.setOnItemSelectedListener(this);
        ArrayAdapter aa=new ArrayAdapter(this,android.R.layout.simple_spinner_item,categories);
        aa.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spin.setAdapter(aa);
        //////Date Picker//////
        tvw=(TextView)findViewById(R.id.textView1);
        eText=(EditText) findViewById(R.id.get_date);
        eText.setInputType(InputType.TYPE_NULL);
        eText.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.N)
            @Override
            public void onClick(View v) {
                final Calendar cldr = Calendar.getInstance();
                int day = cldr.get(Calendar.DAY_OF_MONTH);
                int month = cldr.get(Calendar.MONTH);
                int year = cldr.get(Calendar.YEAR);

                picker=new DatePickerDialog(ExpensesActivity.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                        date=dayOfMonth + "-" + (monthOfYear + 1) + "-" + year;
                        eText.setText(date);
                    }
                },year,month,day);
                picker.show();
            }
        });
        ///////Add Items into table////////
        final EditText edt2=(EditText)findViewById(R.id.get_income);
        final EditText edt3=(EditText)findViewById(R.id.get_date);


        btn=(Button)findViewById(R.id.Add_category);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                expense=String.valueOf(edt2.getText());

                if(!(expense.equals("")) && !(date.equals(""))){
                    insert_items(expense,date,items,id);
                    makeText(getApplicationContext(), "Expenses Inserted", LENGTH_LONG).show();
                }
                else{
                    makeText(getApplicationContext(), "Problem during Insertion", LENGTH_LONG).show();
                }


            }
        });
    }


    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        items = categories[position];
        Toast.makeText(getApplicationContext(), categories[position], Toast.LENGTH_LONG).show();

    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    public boolean insert_items(String amount, String date,String category,int id){
        SQLiteDatabase db = mydb.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(DBContractClass.FeedExpense.COL1, amount);
        contentValues.put(DBContractClass.FeedExpense.COL2, date);
        contentValues.put(DBContractClass.FeedExpense.COL3, category);
        contentValues.put(DBContractClass.FeedExpense.COL4, id);
        


        long result = db.insert(DBContractClass.FeedExpense.TABLE, null, contentValues);

        if(result==-1){
            return false;
        }else{
            return true;
        }
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
    }
}
