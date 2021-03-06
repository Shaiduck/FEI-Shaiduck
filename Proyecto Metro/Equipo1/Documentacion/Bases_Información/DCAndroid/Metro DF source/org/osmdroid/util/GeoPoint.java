package org.osmdroid.util;

import android.location.Location;
import android.os.Parcel;
import android.os.Parcelable;
import android.os.Parcelable.Creator;
import java.io.Serializable;
import org.osmdroid.api.IGeoPoint;
import org.osmdroid.util.constants.GeoConstants;
import org.osmdroid.views.util.constants.MathConstants;

public class GeoPoint
  implements IGeoPoint, MathConstants, GeoConstants, Parcelable, Serializable, Cloneable
{
  public static final Parcelable.Creator<GeoPoint> CREATOR = new Parcelable.Creator()
  {
    public GeoPoint createFromParcel(Parcel paramParcel)
    {
      return new GeoPoint(paramParcel, null);
    }

    public GeoPoint[] newArray(int paramInt)
    {
      return new GeoPoint[paramInt];
    }
  };
  static final long serialVersionUID = 1L;
  private int mAltitude;
  private int mLatitudeE6;
  private int mLongitudeE6;

  public GeoPoint(double paramDouble1, double paramDouble2)
  {
    this.mLatitudeE6 = (int)(paramDouble1 * 1000000.0D);
    this.mLongitudeE6 = (int)(paramDouble2 * 1000000.0D);
  }

  public GeoPoint(double paramDouble1, double paramDouble2, double paramDouble3)
  {
    this.mLatitudeE6 = (int)(paramDouble1 * 1000000.0D);
    this.mLongitudeE6 = (int)(paramDouble2 * 1000000.0D);
    this.mAltitude = (int)paramDouble3;
  }

  public GeoPoint(int paramInt1, int paramInt2)
  {
    this.mLatitudeE6 = paramInt1;
    this.mLongitudeE6 = paramInt2;
  }

  public GeoPoint(int paramInt1, int paramInt2, int paramInt3)
  {
    this.mLatitudeE6 = paramInt1;
    this.mLongitudeE6 = paramInt2;
    this.mAltitude = paramInt3;
  }

  public GeoPoint(Location paramLocation)
  {
    this(paramLocation.getLatitude(), paramLocation.getLongitude(), paramLocation.getAltitude());
  }

  private GeoPoint(Parcel paramParcel)
  {
    this.mLatitudeE6 = paramParcel.readInt();
    this.mLongitudeE6 = paramParcel.readInt();
    this.mAltitude = paramParcel.readInt();
  }

  public GeoPoint(GeoPoint paramGeoPoint)
  {
    this.mLatitudeE6 = paramGeoPoint.mLatitudeE6;
    this.mLongitudeE6 = paramGeoPoint.mLongitudeE6;
    this.mAltitude = paramGeoPoint.mAltitude;
  }

  public static GeoPoint fromCenterBetween(GeoPoint paramGeoPoint1, GeoPoint paramGeoPoint2)
  {
    return new GeoPoint((paramGeoPoint1.getLatitudeE6() + paramGeoPoint2.getLatitudeE6()) / 2, (paramGeoPoint1.getLongitudeE6() + paramGeoPoint2.getLongitudeE6()) / 2);
  }

  public static GeoPoint fromDoubleString(String paramString, char paramChar)
  {
    int i = paramString.indexOf(paramChar);
    int j = paramString.indexOf(paramChar, i + 1);
    if (j == -1)
      return new GeoPoint((int)(1000000.0D * Double.parseDouble(paramString.substring(0, i))), (int)(1000000.0D * Double.parseDouble(paramString.substring(i + 1, paramString.length()))));
    return new GeoPoint((int)(1000000.0D * Double.parseDouble(paramString.substring(0, i))), (int)(1000000.0D * Double.parseDouble(paramString.substring(i + 1, j))), (int)Double.parseDouble(paramString.substring(j + 1, paramString.length())));
  }

  public static GeoPoint fromIntString(String paramString)
  {
    int i = paramString.indexOf(',');
    int j = paramString.indexOf(',', i + 1);
    if (j == -1)
      return new GeoPoint(Integer.parseInt(paramString.substring(0, i)), Integer.parseInt(paramString.substring(i + 1, paramString.length())));
    return new GeoPoint(Integer.parseInt(paramString.substring(0, i)), Integer.parseInt(paramString.substring(i + 1, j)), Integer.parseInt(paramString.substring(j + 1, paramString.length())));
  }

  public static GeoPoint fromInvertedDoubleString(String paramString, char paramChar)
  {
    int i = paramString.indexOf(paramChar);
    int j = paramString.indexOf(paramChar, i + 1);
    if (j == -1)
      return new GeoPoint((int)(1000000.0D * Double.parseDouble(paramString.substring(i + 1, paramString.length()))), (int)(1000000.0D * Double.parseDouble(paramString.substring(0, i))));
    return new GeoPoint((int)(1000000.0D * Double.parseDouble(paramString.substring(i + 1, j))), (int)(1000000.0D * Double.parseDouble(paramString.substring(0, i))), (int)Double.parseDouble(paramString.substring(j + 1, paramString.length())));
  }

  public double bearingTo(GeoPoint paramGeoPoint)
  {
    double d1 = Math.toRadians(this.mLatitudeE6 / 1000000.0D);
    double d2 = Math.toRadians(this.mLongitudeE6 / 1000000.0D);
    double d3 = Math.toRadians(paramGeoPoint.mLatitudeE6 / 1000000.0D);
    double d4 = Math.toRadians(paramGeoPoint.mLongitudeE6 / 1000000.0D) - d2;
    return (360.0D + Math.toDegrees(Math.atan2(Math.sin(d4) * Math.cos(d3), Math.cos(d1) * Math.sin(d3) - Math.sin(d1) * Math.cos(d3) * Math.cos(d4)))) % 360.0D;
  }

  public Object clone()
  {
    return new GeoPoint(this.mLatitudeE6, this.mLongitudeE6);
  }

  public int describeContents()
  {
    return 0;
  }

  public GeoPoint destinationPoint(double paramDouble, float paramFloat)
  {
    double d1 = paramDouble / 6378137.0D;
    float f = 0.01745329F * paramFloat;
    double d2 = 0.01745329F * getLatitudeE6() / 1000000.0D;
    double d3 = 0.01745329F * getLongitudeE6() / 1000000.0D;
    double d4 = Math.asin(Math.sin(d2) * Math.cos(d1) + Math.cos(d2) * Math.sin(d1) * Math.cos(f));
    double d5 = d3 + Math.atan2(Math.sin(f) * Math.sin(d1) * Math.cos(d2), Math.cos(d1) - Math.sin(d2) * Math.sin(d4));
    double d6 = d4 / 0.0174532923847437D;
    double d7 = d5 / 0.0174532923847437D;
    GeoPoint localGeoPoint = new GeoPoint(d6, d7);
    return localGeoPoint;
  }

  public int distanceTo(GeoPoint paramGeoPoint)
  {
    double d1 = 0.01745329F * this.mLatitudeE6 / 1000000.0D;
    double d2 = 0.01745329F * this.mLongitudeE6 / 1000000.0D;
    double d3 = 0.01745329F * paramGeoPoint.mLatitudeE6 / 1000000.0D;
    double d4 = 0.01745329F * paramGeoPoint.mLongitudeE6 / 1000000.0D;
    double d5 = Math.cos(d1);
    double d6 = Math.cos(d3);
    double d7 = d6 * (d5 * Math.cos(d2)) * Math.cos(d4);
    double d8 = d6 * (d5 * Math.sin(d2)) * Math.sin(d4);
    return (int)(6378137.0D * Math.acos(Math.sin(d1) * Math.sin(d3) + (d7 + d8)));
  }

  public boolean equals(Object paramObject)
  {
    if (paramObject == null);
    GeoPoint localGeoPoint;
    do
    {
      do
      {
        return false;
        if (paramObject == this)
          return true;
      }
      while (paramObject.getClass() != getClass());
      localGeoPoint = (GeoPoint)paramObject;
    }
    while ((localGeoPoint.mLatitudeE6 != this.mLatitudeE6) || (localGeoPoint.mLongitudeE6 != this.mLongitudeE6) || (localGeoPoint.mAltitude != this.mAltitude));
    return true;
  }

  public int getAltitude()
  {
    return this.mAltitude;
  }

  public int getLatitudeE6()
  {
    return this.mLatitudeE6;
  }

  public int getLongitudeE6()
  {
    return this.mLongitudeE6;
  }

  public int hashCode()
  {
    return 37 * (17 * this.mLatitudeE6 + this.mLongitudeE6) + this.mAltitude;
  }

  public void setAltitude(int paramInt)
  {
    this.mAltitude = paramInt;
  }

  public void setCoordsE6(int paramInt1, int paramInt2)
  {
    this.mLatitudeE6 = paramInt1;
    this.mLongitudeE6 = paramInt2;
  }

  public void setLatitudeE6(int paramInt)
  {
    this.mLatitudeE6 = paramInt;
  }

  public void setLongitudeE6(int paramInt)
  {
    this.mLongitudeE6 = paramInt;
  }

  public String toDoubleString()
  {
    return this.mLatitudeE6 / 1000000.0D + "," + this.mLongitudeE6 / 1000000.0D + "," + this.mAltitude;
  }

  public String toInvertedDoubleString()
  {
    return this.mLongitudeE6 / 1000000.0D + "," + this.mLatitudeE6 / 1000000.0D + "," + this.mAltitude;
  }

  public String toString()
  {
    return this.mLatitudeE6 + "," + this.mLongitudeE6 + "," + this.mAltitude;
  }

  public void writeToParcel(Parcel paramParcel, int paramInt)
  {
    paramParcel.writeInt(this.mLatitudeE6);
    paramParcel.writeInt(this.mLongitudeE6);
    paramParcel.writeInt(this.mAltitude);
  }
}

/* Location:           C:\DCAndroid\classes-dex2jar.jar
 * Qualified Name:     org.osmdroid.util.GeoPoint
 * JD-Core Version:    0.6.0
 */