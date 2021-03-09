package com.anonic.remotedesk;

import android.os.AsyncTask;
import android.util.Log;

import java.io.DataOutputStream;
import java.net.Socket;

public class ConnectionCloser extends AsyncTask<Void,Void,Void> {

    private Socket socket;
    private String msg;

    public ConnectionCloser(Socket socket, String msg) {
        this.socket=socket;
        this.msg = msg;
    }

    @Override
    protected Void doInBackground(Void... voids) {
        try {
            DataOutputStream outputStream=new DataOutputStream(socket.getOutputStream());
            outputStream.writeUTF(msg);
            socket.close();
        }catch (Exception e) {
            Log.d("ASOFT",e.toString());
        }
        return null;
    }
}
