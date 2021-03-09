package com.anonic.remotedesk;

import android.content.Context;
import android.content.SharedPreferences;
import android.content.res.AssetFileDescriptor;
import android.media.MediaPlayer;

import static android.content.Context.MODE_PRIVATE;

public class Utils {
    public void saveSetting(Context ctx,String setting, boolean b) {
        SharedPreferences.Editor editor = ctx.getSharedPreferences("com.akansh.remotedesk", MODE_PRIVATE).edit();
        editor.putBoolean(setting,b);
        editor.apply();
    }
    public boolean loadSetting(Context ctx,String setting) {
        SharedPreferences sharedPrefs = ctx.getSharedPreferences("com.akansh.remotedesk", MODE_PRIVATE);
        return sharedPrefs.getBoolean(setting,false);
    }

    public static void playAssetSound(Context context, String soundFileName) {
        try {
            MediaPlayer mediaPlayer = new MediaPlayer();
            AssetFileDescriptor descriptor = context.getAssets().openFd(soundFileName);
            mediaPlayer.setDataSource(descriptor.getFileDescriptor(), descriptor.getStartOffset(), descriptor.getLength());
            descriptor.close();
            mediaPlayer.prepare();
            mediaPlayer.setVolume(1f, 1f);
            mediaPlayer.setLooping(false);
            mediaPlayer.start();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
