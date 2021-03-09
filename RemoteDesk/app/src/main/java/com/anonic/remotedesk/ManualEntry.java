package com.anonic.remotedesk;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatDialogFragment;

public class ManualEntry extends AppCompatDialogFragment {

    private EditText ipAddr,port;
    private Button connect,cancel;
    private ManualEntryListener listener;

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder=new AlertDialog.Builder(getActivity());
        LayoutInflater inflater=getActivity().getLayoutInflater();
        View view=inflater.inflate(R.layout.manual_entry,null);
        builder.setView(view);
        ipAddr=view.findViewById(R.id.d_ipAddr);
        port=view.findViewById(R.id.d_port);
        connect=view.findViewById(R.id.d_btnConnect);
        cancel=view.findViewById(R.id.d_btnCancel);
        connect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String ip=ipAddr.getText().toString();
                String prt=port.getText().toString();
                listener.onConnectListener(ip,prt);
            }
        });
        cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ManualEntry.this.dismiss();
            }
        });
        return builder.create();
    }

    @Override
    public void onAttach(@NonNull Context context) {
        super.onAttach(context);
        try {
            listener = (ManualEntryListener) context;
        } catch (Exception e) {
            //Do Nothing!
        }
    }

    public interface ManualEntryListener {
        void onConnectListener(String ip,String prt);
    }
}
