using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;



namespace ThreadWanderer
{
  public partial class Form1 : Form
  {
    static CDrawer canvas = new CDrawer(1000, 1000);
    Point click;
    static Random rand = new Random();

    public delegate void voidWrap(Point p,Color c);
    public static voidWrap handler = drawPath;

    public Form1()
    {
      InitializeComponent();
    }
    public void raiseWanderer(){
      Wanderer w = new Wanderer(click, RandColor.GetColor(), canvas,this);
      Thread t = new Thread(w.wander);
      t.IsBackground = true;
      t.Start();
    }
    public static void drawPath(Point p, Color c)
    {
      canvas.SetBBScaledPixel(p.X, p.Y, c);
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
      if (canvas.GetLastMouseLeftClick(out click))
      {
        this.raiseWanderer();
      }
      if (canvas.GetLastMouseRightClick(out click))
      {
        if (Wanderer.run) Wanderer.run = false;
        else Wanderer.run = true;
        
      }

    }
    public class  Wanderer
    {
      private Point start;
      private Color color;
      private CDrawer canvas;
      public static bool run;
      private Form1 form;
      public Wanderer(Point start,Color color,CDrawer canvas,Form1 frm){
        this.start = start;
        this.color = color;
        this.canvas = canvas;
        run = true;
        this.form = frm;
      }
      public void kill()
      {
        run = false;
      }
      public void wander()
      {
        while (true)
        {
          Thread.Sleep(1);
          if (run)
          {
            int velocityX = rand.Next(3) - 1;
            int velocityY = rand.Next(3) - 1;
            Point temp = new Point(start.X + velocityX, start.Y + velocityY);
            if (temp.X >= 0 && temp.X < canvas.ScaledWidth && temp.Y >= 0 && temp.Y < canvas.ScaledHeight)
            {
              object[] obj = { temp, color };
              this.form.BeginInvoke(handler, obj);
              
              start = temp;
            }

          }
        }
      }
    }
    

    
       
  }
  
}
