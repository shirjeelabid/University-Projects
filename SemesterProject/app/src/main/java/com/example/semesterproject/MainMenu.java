package com.example.semesterproject;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBarDrawerToggle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.drawerlayout.widget.DrawerLayout;

import android.app.Activity;
import android.app.slice.Slice;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.navigation.NavigationView;

import java.util.ArrayList;
import java.util.List;

import lecho.lib.hellocharts.model.PieChartData;
import lecho.lib.hellocharts.model.SliceValue;
import lecho.lib.hellocharts.view.PieChartView;

public class MainMenu extends AppCompatActivity {

    private DrawerLayout dl;
    private ActionBarDrawerToggle abdt;
    private NavigationView nv;
    private int id;
    DatabaseHelper helper;

    @Override
    protected void onStart() {
        super.onStart();
        try {
            showStats();
        }
        catch(Exception e){
            Toast.makeText(getApplicationContext(),e.getMessage(),Toast.LENGTH_LONG).show();
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_menu);
        helper = new DatabaseHelper(this);
        Intent intent = getIntent();
        id = intent.getIntExtra("id", -1);
        //showStats();

        dl = findViewById(R.id.dl);
        abdt = new ActionBarDrawerToggle(this, dl, R.string.Open, R.string.Close);
        abdt.setDrawerIndicatorEnabled(true);
        dl.addDrawerListener(abdt);
        nv = findViewById(R.id.nv);
        nv.setItemIconTintList(null);
        abdt.syncState();
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        NavigationView navigationView = (NavigationView) findViewById(R.id.nv);
        navigationView.setItemIconTintList(null);
        navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {
                int id = menuItem.getItemId();
                dl = (DrawerLayout) findViewById(R.id.dl);
                dl.closeDrawers();

                if (id == R.id.MyExpenses) {
                    expenses_activity();
                }

                if (id == R.id.ViewExp) {
                    view_activity();
                }

                if (id == R.id.MyIncome) {
                    income_activity();
                }


                if (id == R.id.LogOut) {
                    signin_activity();
                    finish();
                }



                return true;
            }
        });

    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        return abdt.onOptionsItemSelected(item) || super.onOptionsItemSelected(item);
    }

    public void expenses_activity() {
        Intent intent = new Intent(MainMenu.this, ExpensesActivity.class);
        intent.putExtra("id", id);
        startActivity(intent);
    }

    public void income_activity() {
        Intent intent = new Intent(MainMenu.this, IncomeActivity.class);
        intent.putExtra("id", id);
        startActivity(intent);
    }

    public void view_activity() {
        Intent intent = new Intent(MainMenu.this, ViewExpensesActivity.class);
        intent.putExtra("id", id);
        startActivity(intent);
    }


    public void signin_activity() {
        Intent intent = new Intent(MainMenu.this, MainActivity.class);
        startActivity(intent);
    }

    public void showStats() {
        SQLiteDatabase database = helper.getReadableDatabase();

        String expense = "SELECT sum(e." + DBContractClass.FeedExpense.COL1 + ") As 'Expense' from "
                + DBContractClass.FeedExpense.TABLE + " e WHERE e." + DBContractClass.FeedExpense.COL4 + "=" + id;
        String income = "SELECT sum(i." + DBContractClass.FeedIncome.C1 + ") As 'Income' from "
                + DBContractClass.FeedIncome.TABLE_3 + " i WHERE i." + DBContractClass.FeedIncome.C2 + "=" + id + ";";

        Cursor leftCursor = database.rawQuery(expense, null);
        int expenses = 0;
        if (leftCursor.getCount() > 0) {
            leftCursor.moveToFirst();
            expenses = leftCursor.getInt(leftCursor.getColumnIndexOrThrow("Expense"));
        }

        leftCursor.close();

        leftCursor = database.rawQuery(income, null);
        int incomes = 0;

        if(leftCursor.getCount()>0) {
            leftCursor.moveToFirst();

            incomes = leftCursor.getInt(leftCursor.getColumnIndexOrThrow("Income"));
        }

        TextView tv1, tv2, tv3;

        tv1 = (TextView) findViewById(R.id.income_left);
        tv2 = (TextView) findViewById(R.id.expense);
        tv3 = (TextView) findViewById(R.id.income);

            tv1.setText(String.valueOf(incomes-expenses));

            tv3.setText(String.valueOf(incomes));
            tv2.setText(String.valueOf(expenses));


        ShowPieChart(expenses);
    }

    public Cursor getExpenses(){
        SQLiteDatabase database = helper.getReadableDatabase();

       String query = "SELECT SUM("+DBContractClass.FeedExpense.COL1+"),"+ DBContractClass.FeedExpense.COL3 +" FROM "+DBContractClass.FeedExpense.TABLE+" WHERE "+ DBContractClass.FeedExpense.COL4+"="+id+" GROUP BY "+ DBContractClass.FeedExpense.COL3;
       Cursor cursor = database.rawQuery(query,null);
       return cursor;
    }

    public void ShowPieChart(int total)
    {
        PieChartView pieChartView = findViewById(R.id.expense_piechart);
        List<SliceValue> data = new ArrayList<>();
        SliceValue sliceValue;
        Cursor cursor = getExpenses();
        int color = 0,i=0;

        if(cursor.getCount()>0)
        {
            cursor.moveToFirst();
            do{
                if(i == 0)
                    color = Color.RED;

                else if(i==1)
                    color = Color.BLUE;


                else if(i==2)
                    color = Color.YELLOW;


                else if(i==3)
                    color = Color.CYAN;


                else if(i==4)
                    color = Color.GRAY;


                else if(i==5)
                    color = Color.MAGENTA;

                sliceValue = new SliceValue((100*cursor.getInt(0)/total),color).setLabel(cursor.getString(1));
                data.add(sliceValue);
                i++;

            }while (cursor.moveToNext());

            PieChartData chartData = new PieChartData(data).setHasLabels(true);
            pieChartView.setPieChartData(chartData);
            return;
        }
        pieChartView.setPieChartData(null);

    }

}
