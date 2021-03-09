package com.anonic.remotedesk;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.VibrationEffect;
import android.os.Vibrator;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

//import com.google.android.gms.ads.AdListener;
//import com.google.android.gms.ads.AdRequest;
//import com.google.android.gms.ads.AdView;
//import com.google.android.gms.ads.InterstitialAd;
//import com.google.android.gms.ads.MobileAds;
//import com.google.android.gms.ads.initialization.InitializationStatus;
//import com.google.android.gms.ads.initialization.OnInitializationCompleteListener;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Timer;
import java.util.TimerTask;

public class MainActivity extends AppCompatActivity implements ManualEntry.ManualEntryListener {

    private TextView top_panel_msg;
    private ConstraintLayout top_panel;
    private ManualEntry manualEntry=new ManualEntry();
    private Socket sock;

    private ServerSocket serverSocket;

    private DataInputStream in;
    private DataOutputStream out;
    private String ipAddress,m_port;
    private Switch mode_switch;
    private ConstraintLayout keyboard_layout,mousepad_layout;
    private Utils utils;
//    private AdView adView;
//    private InterstitialAd mInterstitialAd;


    float initX=0,initY=0,distX=0,distY=0;
    boolean mouseMoved=false;
    float x1,x2,x3,y1,y2,y3;
    int x,exit=0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            requestPermissions();
        }

        //      Initialise Ads Start
//        MobileAds.initialize(this, new OnInitializationCompleteListener() {
//            @Override
//            public void onInitializationComplete(InitializationStatus initializationStatus) {
//            adView=findViewById(R.id.adView);
//            mInterstitialAd = new InterstitialAd(MainActivity.this);
//            mInterstitialAd.setAdUnitId("ca-app-pub-3535677166224536/6650655136");
//            mInterstitialAd.loadAd(new AdRequest.Builder().build());
//            mInterstitialAd.setAdListener(new AdListener() {
//                @Override
//                public void onAdClosed() {
//                    mInterstitialAd.loadAd(new AdRequest.Builder().build());
//                }
//                @Override
//                public void onAdFailedToLoad(int i) {
//                    if(i==3) {
//                        mInterstitialAd.loadAd(new AdRequest.Builder().build());
//                    }
//                }
//            });
//            adView.loadAd(new AdRequest.Builder().build());
//            adView.setAdListener(new AdListener() {
//                @Override
//                public void onAdFailedToLoad(int i) {
//                    if(i==3) {
//                        adView.loadAd(new AdRequest.Builder().build());
//                    }
//                }
//            });
//            }
//        });
        //      Initialise Ads Stop

        top_panel_msg=findViewById(R.id.top_panel_msg);
        top_panel=findViewById(R.id.top_panel);

        utils=new Utils();
        mousepad_layout=findViewById(R.id.mousepad_layout);
        keyboard_layout=findViewById(R.id.keyboard_layout);
        mode_switch=findViewById(R.id.mode_switch);
        mode_switch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                final Animation go = AnimationUtils.loadAnimation(getApplicationContext(), R.anim.fade_out);
                final Animation come=AnimationUtils.loadAnimation(getApplicationContext(), R.anim.fade_in);
                if(b) {
                    keyboard_layout.startAnimation(go);
                    come.setAnimationListener(new Animation.AnimationListener() {
                        @Override
                        public void onAnimationStart(Animation animation) {
                            mousepad_layout.setVisibility(View.VISIBLE);
                        }
                        @Override
                        public void onAnimationEnd(Animation animation) {

                        }
                        @Override
                        public void onAnimationRepeat(Animation animation) {

                        }
                    });
                    go.setAnimationListener(new Animation.AnimationListener() {
                        @Override
                        public void onAnimationStart(Animation animation) {

                        }
                        @Override
                        public void onAnimationEnd(Animation animation) {
                            keyboard_layout.setVisibility(View.GONE);
                            mousepad_layout.startAnimation(come);
                        }
                        @Override
                        public void onAnimationRepeat(Animation animation) {

                        }
                    });
                }else{
                    mousepad_layout.startAnimation(go);
                    come.setAnimationListener(new Animation.AnimationListener() {
                        @Override
                        public void onAnimationStart(Animation animation) {
                            keyboard_layout.setVisibility(View.VISIBLE);
                        }

                        @Override
                        public void onAnimationEnd(Animation animation) {

                        }

                        @Override
                        public void onAnimationRepeat(Animation animation) {

                        }
                    });
                    go.setAnimationListener(new Animation.AnimationListener() {
                        @Override
                        public void onAnimationStart(Animation animation) {

                        }

                        @Override
                        public void onAnimationEnd(Animation animation) {
                            mousepad_layout.setVisibility(View.GONE);
                            keyboard_layout.startAnimation(come);
                        }
                        @Override
                        public void onAnimationRepeat(Animation animation) {

                        }
                    });
                }
            }
        });
        ImageButton imageButton=findViewById(R.id.clearAllBtn);
        imageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText inputPad=findViewById(R.id.inputPad);
                inputPad.setText("");
            }
        });
        initControls();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        if(requestCode==101) {
            String d=data.getStringExtra("data");
            if(d.length()>0) {
                String[] conn = d.split(";");
                ipAddress=conn[1];
                m_port=conn[2];
                ConnectionEstablish connectionEstablish = new ConnectionEstablish();
                connectionEstablish.execute(ipAddress, m_port);
            }
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

    private void requestPermissions() {
        String[] PERMISSIONS={
                Manifest.permission.CAMERA,
                Manifest.permission.INTERNET,
                Manifest.permission.ACCESS_WIFI_STATE,
                Manifest.permission.ACCESS_NETWORK_STATE,
                Manifest.permission.VIBRATE
        };
        int[] permissions = {
                ActivityCompat.checkSelfPermission(this, PERMISSIONS[0]),
                ActivityCompat.checkSelfPermission(this, PERMISSIONS[1]),
                ActivityCompat.checkSelfPermission(this, PERMISSIONS[2]),
                ActivityCompat.checkSelfPermission(this, PERMISSIONS[3]),
                ActivityCompat.checkSelfPermission(this, PERMISSIONS[4]),
        };
        for(int i=0; i<permissions.length; i++) {
            if(permissions[i] != PackageManager.PERMISSION_GRANTED) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    requestPermissions(PERMISSIONS,1);
                }
            }
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater=getMenuInflater();
        inflater.inflate(R.menu.menu_actions,menu);
        menu.getItem(4).setChecked(utils.loadSetting(this,Constants.TOUCH_VIBRATE_SETTING));
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch(item.getItemId()) {
            case R.id.m_scan:
                Intent intent=new Intent(MainActivity.this,QrScanner.class);
                startActivityForResult(intent, 101);
                break;
            case R.id.m_conn:
                openDialog();
                break;
            case R.id.m_discon:
                if(sock!=null) {
                    try {
                        ConnectionCloser connectionCloser=new ConnectionCloser(sock,"ANSOFT:Client Disconnected!");
                        connectionCloser.execute();
                        changeLabel("Disconnected!",0);
                    }catch (Exception e) {
                        changeLabel("Disconnect Error!",0);
                    }
                }
                showAd();
                break;
            case R.id.m_recon:
                try {
                    if (ipAddress.length() > 0 && m_port.length() > 0) {
                        ConnectionEstablish connectionEstablish = new ConnectionEstablish();
                        connectionEstablish.execute(ipAddress, m_port);
                    }
                }catch (Exception e) {
                    //Do Nothing!
                }
                break;
            case R.id.m_vibrate:
                if(utils.loadSetting(this,Constants.TOUCH_VIBRATE_SETTING)) {
                    utils.saveSetting(this,Constants.TOUCH_VIBRATE_SETTING,false);
                    item.setChecked(false);
                }else{
                    utils.saveSetting(this,Constants.TOUCH_VIBRATE_SETTING,true);
                    item.setChecked(true);
                }
                break;
            case R.id.m_dwlCli:
                String url = "https://akanshsirohi.github.io/Remote-Desk/";
                Intent i = new Intent(Intent.ACTION_VIEW);
                i.setData(Uri.parse(url));
                startActivity(i);
                break;
        }
        return true;
    }

    private void openDialog() {
        manualEntry.setCancelable(false);
        manualEntry.show(getSupportFragmentManager(),"");
    }

    @Override
    public void onConnectListener(String ip, String prt) {
        ipAddress=ip;
        m_port=prt;
        if(ipAddress.length()>0 && m_port.length()>0) {
            ConnectionEstablish connectionEstablish = new ConnectionEstablish();
            connectionEstablish.execute(ipAddress, m_port);
        }
        manualEntry.dismiss();
    }

    public class ConnectionEstablish extends AsyncTask<String,Void,Void> {

        @Override
        protected Void doInBackground(String... data) {
            try {
                sock = new Socket(data[0],Integer.valueOf(data[1]));
                in = new DataInputStream(sock.getInputStream());
                out = new DataOutputStream(sock.getOutputStream());
                out.writeUTF("ANSOFT:Client Connected!");
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        changeLabel("Connected!",1);
//                        showAd();
                    }
                });
            }catch (final Exception e) {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        changeLabel("Connection Error!",0);
                    }
                });
            }
            return null;
        }
    }

//    public class StartServer extends AsyncTask<Void,Void,Void> {
//
//        @Override
//        protected Void doInBackground(Void... voids) {
//            try {
//                serverSocket = new ServerSocket(6060,10,InetAddress.getByName("192.168.43.1"));
//                Log.d("ANSOFT",serverSocket.getInetAddress().toString());
//                while(true) {
//                    Log.d("ANSOFT", "Waiting for client on port " +
//                            serverSocket.getLocalPort() + "...");
//                    Socket clientSocket = serverSocket.accept();
//
//                    Log.d("ANSOFT","Just connected to " + clientSocket.getRemoteSocketAddress());
//                    DataInputStream in = new DataInputStream(clientSocket.getInputStream());
//                    Log.d("ANOSFT","Client: "+in.readUTF());
//                    DataOutputStream out = new DataOutputStream(clientSocket.getOutputStream());
//                    out.writeUTF("Thank you for connecting to " + clientSocket.getLocalSocketAddress()
//                            + "\nGoodbye!");
////                    clientSocket.close();
//                }
//            }catch (Exception e) {
//                Log.d("ANSOFT",e.toString());
//            }
//            return null;
//        }
//    }

    private void changeLabel(String msg,int i) {
        top_panel_msg.setText(msg);
        if(i==0) {
            top_panel.setBackgroundColor(getResources().getColor(R.color.colorError));
        }else{
            top_panel.setBackgroundColor(getResources().getColor(R.color.colorAccent));
        }
    }

    private void vibrate() {
        try {
            Vibrator vibrator=(Vibrator) getSystemService(Context.VIBRATOR_SERVICE);
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                vibrator.vibrate(VibrationEffect.createOneShot(80,VibrationEffect.DEFAULT_AMPLITUDE));
            }else{
                vibrator.vibrate(80);
            }
        }catch (Exception e) {

        }
    }

    private void keyPress(String code) {
        MessageSender messageSender=new MessageSender(sock,code);
        messageSender.execute();
        if(utils.loadSetting(this,Constants.TOUCH_VIBRATE_SETTING)) {
            vibrate();
        }
    }

    private void mouseMove(String code) {
        MessageSender messageSender=new MessageSender(sock,code);
        messageSender.execute();
    }

    private void type(String code) {
        MessageSender messageSender=new MessageSender(sock,code);
        messageSender.execute();
    }

    @SuppressLint("ClickableViewAccessibility")
    private void initControls() {
        TextView mousePad=findViewById(R.id.mousePad);
        EditText inputPad=findViewById(R.id.inputPad);

        TextView left_m,right_m;
        left_m=findViewById(R.id.left_m);
        right_m=findViewById(R.id.right_m);

        FloatingActionButton fab_capsLock,fab_upArr,fab_downArr,fab_leftArr,fab_rightArr,fab_f5,fab_esc,fab_backspace,fab_enter,fab_cut,fab_copy,fab_paste,fab_ss,fab_win;
        fab_upArr=findViewById(R.id.fab_upArr);
        fab_downArr=findViewById(R.id.fab_downArr);
        fab_leftArr=findViewById(R.id.fab_leftArr);
        fab_rightArr=findViewById(R.id.fab_rightArr);
        fab_capsLock=findViewById(R.id.fab_capsLock);
        fab_f5=findViewById(R.id.fab_f5);
        fab_esc=findViewById(R.id.fab_esc);
        fab_backspace=findViewById(R.id.fab_backspace);
        fab_enter=findViewById(R.id.fab_enter);
        fab_cut=findViewById(R.id.fab_cut);
        fab_copy=findViewById(R.id.fab_copy);
        fab_paste=findViewById(R.id.fab_paste);
        fab_ss=findViewById(R.id.fab_ss);
        fab_win=findViewById(R.id.fab_win);
        fab_capsLock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_c_lck_");
            }
        });
        fab_upArr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_up_");
            }
        });
        fab_downArr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_dwn_");
            }
        });
        fab_leftArr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_left_");
            }
        });
        fab_rightArr.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_rght_");
            }
        });
        fab_f5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_f5_");
            }
        });
        fab_esc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_esc_");
            }
        });
        fab_backspace.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_bksp_");
            }
        });
        fab_enter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_enter_");
            }
        });
        fab_cut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_stct_cut_");
            }
        });
        fab_copy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_stct_cpy_");
            }
        });
        fab_paste.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_stct_pst_");
            }
        });
        fab_ss.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_stct_ss_");
            }
        });
        fab_win.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_stct_win_");
            }
        });
        mousePad.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View view, MotionEvent motionEvent) {
                switch(motionEvent.getAction()) {
                    case MotionEvent.ACTION_DOWN:
                        initX=motionEvent.getX();
                        initY=motionEvent.getY();
                        x1=initX;
                        y1=initY;
                        mouseMoved=false;
                        break;
                    case MotionEvent.ACTION_MOVE:
                        x2=motionEvent.getX();
                        y2=motionEvent.getY();
                        distX=motionEvent.getX()-initX;
                        distY=motionEvent.getY()-initY;
                        initX=motionEvent.getX();
                        initY=motionEvent.getY();
                        if(distX!=0 || distY!=0) {
                            mouseMove("ASOFT_M:"+distX+";"+distY);
                        }
                        mouseMoved=true;
                        break;
                    case MotionEvent.ACTION_UP:
                        x3=motionEvent.getX();
                        y3=motionEvent.getY();
                        if(!mouseMoved) {
                            keyPress("_left_m_");
                        }else{
                            if(x1==x2 && x2==x3) {
                                if(y1==y2 && y2==y3) {
                                    keyPress("_left_m_");
                                }
                            }
                        }
                        break;
                }
                return true;
            }
        });
        inputPad.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                x=charSequence.length();
            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                if(charSequence.length()>0) {
                    if(x<charSequence.length()) {
                        String str = String.valueOf(charSequence);
                        int l=charSequence.length()-x;
                        String txt = str.substring(str.length()-l);
                        type(txt);
                    }
                }
                if(x>charSequence.length()) {
                    type("_bksp_");
                }
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });
        left_m.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_left_m_");
            }
        });
        right_m.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                keyPress("_rght_m_");
            }
        });
    }

    @Override
    public void onBackPressed() {
        exit();
    }

    public void exit() {  //Function For Double Back Exit
        if(exit==0) {
            Toast.makeText(this,"Press One More Time To Exit!",Toast.LENGTH_LONG).show();
            Timer myTimer=new Timer();
            myTimer.schedule(new TimerTask() {
                @Override
                public void run() {
                    exit=0;
                }
            },1000);
            exit++;
        }
        if(exit==1) {
            exit++;
        }else if(exit==2) {
            finishAffinity();
        }
    }

    public void showAd() {
//        if (mInterstitialAd.isLoaded()) {
//            mInterstitialAd.show();
//        }else{
//            Log.d("ANSOFT","AD Not Loaded...");
//        }
    }

}
