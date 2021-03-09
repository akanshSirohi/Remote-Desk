package com.anonic.remotedesk;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.google.zxing.Result;

import me.dm7.barcodescanner.zxing.ZXingScannerView;

public class QrScanner extends AppCompatActivity implements ZXingScannerView.ResultHandler {

    private ZXingScannerView mScannerView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mScannerView = new ZXingScannerView(this);
        setContentView(mScannerView);
    }

    @Override
    public void onResume() {
        super.onResume();
        mScannerView.setResultHandler(this);
        mScannerView.startCamera();
    }

    @Override
    public void onPause() {
        super.onPause();
        mScannerView.stopCamera();
    }

    @Override
    public void onBackPressed() {
        Intent intent=new Intent();
        intent.putExtra("data","");
        setResult(101,intent);
        finish();
    }

    @Override
    public void handleResult(Result rawResult) {
        if(rawResult.getText().startsWith("ANSOFT_CODE;")) {
            Intent intent=new Intent();
            intent.putExtra("data",rawResult.getText());
            setResult(101,intent);
            finish();
        }else{
            mScannerView.resumeCameraPreview(this);
        }
    }
}
