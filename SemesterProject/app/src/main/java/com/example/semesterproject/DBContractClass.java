package com.example.semesterproject;

import android.provider.BaseColumns;

public final class DBContractClass {
    DBContractClass(){

    }
    public static class FeedPerson implements BaseColumns{
        public static final String TABLE_NAME="Person";
        public static final String Col1="Email";
        public static final String Col2="Password";
    }
    public static class FeedExpense implements BaseColumns{
        public static final String TABLE="Expense";
        public static final String COL1="Amount";
        public static final String COL2="Date";
        public static final String COL3="Category";
        public static final String COL4="PID";
    }

    public static class FeedIncome implements BaseColumns{
        public static final String TABLE_3="Income";
        public static final String C1="Amount";
        public static final String C2="UID";
    }





}
