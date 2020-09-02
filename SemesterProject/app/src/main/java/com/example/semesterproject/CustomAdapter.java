package com.example.semesterproject;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.List;

public class CustomAdapter extends ArrayAdapter<Expense> {


    public CustomAdapter(@NonNull Context context, int resource, @NonNull List<Expense> objects) {
        super(context, resource, objects);
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        View view = convertView;

        if(view==null)
        {
            LayoutInflater layoutInflater = LayoutInflater.from(getContext());
            view = layoutInflater.inflate(R.layout.layout_list,null);
        }

        Expense e = getItem(position);

        final TextView id,category,date,amount;
        ImageButton imageButton;


        id = view.findViewById(R.id.ID);
        category = view.findViewById(R.id.Category);
        date = view.findViewById(R.id.Date);
        amount = view.findViewById(R.id.Amount);
        imageButton = view.findViewById(R.id.btnDel);

        id.setText(String.valueOf(e.getId()));
        amount.setText(String.valueOf(e.getAmount()));
        category.setText(e.getCategory());
        date.setText(e.getDate());

        imageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DatabaseHelper db = new DatabaseHelper(getContext());
                db.deleteData(id.getText().toString());
                Toast.makeText(getContext(),"Please click on Refresh button to Refresh",Toast.LENGTH_SHORT).show();
            }
        });

        return  view;
    }


}
