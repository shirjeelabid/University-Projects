package com.example.semesterproject;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;


public class DatabaseHelper extends SQLiteOpenHelper {

    public static final String DATABASE_NAME="Project.db";
    public static int Version=1;

    public DatabaseHelper(@Nullable Context context) {
        super(context, DATABASE_NAME, null, Version);
    }


    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create table "+ DBContractClass.FeedPerson.TABLE_NAME+"("+DBContractClass.FeedPerson._ID+" INTEGER PRIMARY KEY AUTOINCREMENT,"+DBContractClass.FeedPerson.Col1+" TEXT,"+DBContractClass.FeedPerson.Col2+" TEXT)");
        db.execSQL("create table "+DBContractClass.FeedExpense.TABLE+"("+DBContractClass.FeedExpense._ID+" INTEGER PRIMARY KEY AUTOINCREMENT,"+DBContractClass.FeedExpense.COL1+" TEXT,"+DBContractClass.FeedExpense.COL2+" TEXT,"+DBContractClass.FeedExpense.COL3+" TEXT,"+DBContractClass.FeedExpense.COL4+" INT)");
        db.execSQL("create table "+DBContractClass.FeedIncome.TABLE_3+"("+DBContractClass.FeedIncome._ID+" INTEGER PRIMARY KEY AUTOINCREMENT,"+DBContractClass.FeedIncome.C1+" TEXT,"+DBContractClass.FeedIncome.C2+" INTEGER)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS "+DBContractClass.FeedPerson.TABLE_NAME);
        db.execSQL("DROP TABLE IF EXISTS "+DBContractClass.FeedExpense.TABLE);
        db.execSQL("DROP TABLE IF EXISTS "+DBContractClass.FeedIncome.TABLE_3);
        onCreate(db);

    }
    public Cursor viewData(int id){
        SQLiteDatabase db = getReadableDatabase();
        String query = "Select * from "+ DBContractClass.FeedExpense.TABLE+" WHere "+ DBContractClass.FeedExpense.COL4+"=?";
        Cursor cursor = db.rawQuery(query,new String[]{String.valueOf(id)});
        return cursor;
    }

    public void deleteData(String id){
        SQLiteDatabase db = getWritableDatabase();
        db.delete(DBContractClass.FeedExpense.TABLE, DBContractClass.FeedExpense._ID+"=?",new String[]{id});
    }
}
