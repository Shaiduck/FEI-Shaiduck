package com.actionbarsherlock.app;

import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import com.actionbarsherlock.ActionBarSherlock;
import com.actionbarsherlock.ActionBarSherlock.OnActionModeFinishedListener;
import com.actionbarsherlock.ActionBarSherlock.OnActionModeStartedListener;
import com.actionbarsherlock.ActionBarSherlock.OnCreatePanelMenuListener;
import com.actionbarsherlock.ActionBarSherlock.OnMenuItemSelectedListener;
import com.actionbarsherlock.ActionBarSherlock.OnPreparePanelListener;
import com.actionbarsherlock.internal.view.menu.MenuItemMule;
import com.actionbarsherlock.internal.view.menu.MenuMule;
import com.actionbarsherlock.view.ActionMode;
import com.actionbarsherlock.view.ActionMode.Callback;
import com.actionbarsherlock.view.MenuInflater;

public abstract class SherlockFragmentActivity extends FragmentActivity
  implements ActionBarSherlock.OnCreatePanelMenuListener, ActionBarSherlock.OnPreparePanelListener, ActionBarSherlock.OnMenuItemSelectedListener, ActionBarSherlock.OnActionModeStartedListener, ActionBarSherlock.OnActionModeFinishedListener
{
  static final boolean DEBUG = false;
  private static final String TAG = "SherlockFragmentActivity";
  private boolean mIgnoreNativeCreate = false;
  private boolean mIgnoreNativePrepare = false;
  private boolean mIgnoreNativeSelected = false;
  private ActionBarSherlock mSherlock;

  public void addContentView(View paramView, ViewGroup.LayoutParams paramLayoutParams)
  {
    getSherlock().addContentView(paramView, paramLayoutParams);
  }

  public void closeOptionsMenu()
  {
    if (!getSherlock().dispatchCloseOptionsMenu())
      super.closeOptionsMenu();
  }

  public boolean dispatchKeyEvent(KeyEvent paramKeyEvent)
  {
    if (getSherlock().dispatchKeyEvent(paramKeyEvent))
      return true;
    return super.dispatchKeyEvent(paramKeyEvent);
  }

  protected final ActionBarSherlock getSherlock()
  {
    if (this.mSherlock == null)
      this.mSherlock = ActionBarSherlock.wrap(this, 1);
    return this.mSherlock;
  }

  public ActionBar getSupportActionBar()
  {
    return getSherlock().getActionBar();
  }

  public MenuInflater getSupportMenuInflater()
  {
    return getSherlock().getMenuInflater();
  }

  public void invalidateOptionsMenu()
  {
    getSherlock().dispatchInvalidateOptionsMenu();
  }

  public void onActionModeFinished(ActionMode paramActionMode)
  {
  }

  public void onActionModeStarted(ActionMode paramActionMode)
  {
  }

  public void onConfigurationChanged(Configuration paramConfiguration)
  {
    super.onConfigurationChanged(paramConfiguration);
    getSherlock().dispatchConfigurationChanged(paramConfiguration);
  }

  public final boolean onCreateOptionsMenu(android.view.Menu paramMenu)
  {
    return true;
  }

  public boolean onCreateOptionsMenu(com.actionbarsherlock.view.Menu paramMenu)
  {
    return true;
  }

  public final boolean onCreatePanelMenu(int paramInt, android.view.Menu paramMenu)
  {
    if ((paramInt == 0) && (!this.mIgnoreNativeCreate))
    {
      this.mIgnoreNativeCreate = true;
      boolean bool = getSherlock().dispatchCreateOptionsMenu(paramMenu);
      this.mIgnoreNativeCreate = false;
      return bool;
    }
    return super.onCreatePanelMenu(paramInt, paramMenu);
  }

  public boolean onCreatePanelMenu(int paramInt, com.actionbarsherlock.view.Menu paramMenu)
  {
    if (paramInt == 0)
    {
      boolean bool = onCreateOptionsMenu(paramMenu);
      MenuMule localMenuMule = new MenuMule(paramMenu);
      super.onCreatePanelMenu(paramInt, localMenuMule);
      return bool | localMenuMule.mDispatchShow;
    }
    return false;
  }

  public final boolean onMenuItemSelected(int paramInt, android.view.MenuItem paramMenuItem)
  {
    if ((paramInt == 0) && (!this.mIgnoreNativeSelected))
    {
      this.mIgnoreNativeSelected = true;
      boolean bool = getSherlock().dispatchOptionsItemSelected(paramMenuItem);
      this.mIgnoreNativeSelected = false;
      return bool;
    }
    return super.onMenuItemSelected(paramInt, paramMenuItem);
  }

  public boolean onMenuItemSelected(int paramInt, com.actionbarsherlock.view.MenuItem paramMenuItem)
  {
    if (paramInt == 0)
    {
      if (onOptionsItemSelected(paramMenuItem))
        return true;
      return super.onMenuItemSelected(paramInt, new MenuItemMule(paramMenuItem));
    }
    return false;
  }

  public final boolean onMenuOpened(int paramInt, android.view.Menu paramMenu)
  {
    if (getSherlock().dispatchMenuOpened(paramInt, paramMenu))
      return true;
    return super.onMenuOpened(paramInt, paramMenu);
  }

  public final boolean onOptionsItemSelected(android.view.MenuItem paramMenuItem)
  {
    return false;
  }

  public boolean onOptionsItemSelected(com.actionbarsherlock.view.MenuItem paramMenuItem)
  {
    return false;
  }

  public void onPanelClosed(int paramInt, android.view.Menu paramMenu)
  {
    getSherlock().dispatchPanelClosed(paramInt, paramMenu);
    super.onPanelClosed(paramInt, paramMenu);
  }

  protected void onPause()
  {
    getSherlock().dispatchPause();
    super.onPause();
  }

  protected void onPostCreate(Bundle paramBundle)
  {
    getSherlock().dispatchPostCreate(paramBundle);
    super.onPostCreate(paramBundle);
  }

  protected void onPostResume()
  {
    super.onPostResume();
    getSherlock().dispatchPostResume();
  }

  public final boolean onPrepareOptionsMenu(android.view.Menu paramMenu)
  {
    return true;
  }

  public boolean onPrepareOptionsMenu(com.actionbarsherlock.view.Menu paramMenu)
  {
    return true;
  }

  public final boolean onPreparePanel(int paramInt, View paramView, android.view.Menu paramMenu)
  {
    if ((paramInt == 0) && (!this.mIgnoreNativePrepare))
    {
      this.mIgnoreNativePrepare = true;
      boolean bool = getSherlock().dispatchPrepareOptionsMenu(paramMenu);
      this.mIgnoreNativePrepare = false;
      return bool;
    }
    return super.onPreparePanel(paramInt, paramView, paramMenu);
  }

  public boolean onPreparePanel(int paramInt, View paramView, com.actionbarsherlock.view.Menu paramMenu)
  {
    if (paramInt == 0)
    {
      boolean bool = onPrepareOptionsMenu(paramMenu);
      MenuMule localMenuMule = new MenuMule(paramMenu);
      super.onPreparePanel(paramInt, paramView, localMenuMule);
      return (bool | localMenuMule.mDispatchShow) & paramMenu.hasVisibleItems();
    }
    return false;
  }

  protected void onStop()
  {
    getSherlock().dispatchStop();
    super.onStop();
  }

  protected void onTitleChanged(CharSequence paramCharSequence, int paramInt)
  {
    getSherlock().dispatchTitleChanged(paramCharSequence, paramInt);
    super.onTitleChanged(paramCharSequence, paramInt);
  }

  public void openOptionsMenu()
  {
    if (!getSherlock().dispatchOpenOptionsMenu())
      super.openOptionsMenu();
  }

  public void requestWindowFeature(long paramLong)
  {
    getSherlock().requestFeature((int)paramLong);
  }

  public void setContentView(int paramInt)
  {
    getSherlock().setContentView(paramInt);
  }

  public void setContentView(View paramView)
  {
    getSherlock().setContentView(paramView);
  }

  public void setContentView(View paramView, ViewGroup.LayoutParams paramLayoutParams)
  {
    getSherlock().setContentView(paramView, paramLayoutParams);
  }

  public void setSupportProgress(int paramInt)
  {
    getSherlock().setProgress(paramInt);
  }

  public void setSupportProgressBarIndeterminate(boolean paramBoolean)
  {
    getSherlock().setProgressBarIndeterminate(paramBoolean);
  }

  public void setSupportProgressBarIndeterminateVisibility(boolean paramBoolean)
  {
    getSherlock().setProgressBarIndeterminateVisibility(paramBoolean);
  }

  public void setSupportProgressBarVisibility(boolean paramBoolean)
  {
    getSherlock().setProgressBarVisibility(paramBoolean);
  }

  public void setSupportSecondaryProgress(int paramInt)
  {
    getSherlock().setSecondaryProgress(paramInt);
  }

  public ActionMode startActionMode(ActionMode.Callback paramCallback)
  {
    return getSherlock().startActionMode(paramCallback);
  }

  public void supportInvalidateOptionsMenu()
  {
    invalidateOptionsMenu();
  }
}

/* Location:           C:\DCAndroid\classes-dex2jar.jar
 * Qualified Name:     com.actionbarsherlock.app.SherlockFragmentActivity
 * JD-Core Version:    0.6.0
 */