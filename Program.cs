﻿using System;
using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Utils.GtkInit();

        Window win = new Window(WindowType.Toplevel);
        win.SetTitle("GTK.NET Demo");

        win.Destroy += delegate(object sender, Window.DestroySignalArgs e) {
            Console.WriteLine("Bye!");
            Utils.GtkMainQuit();
        };

        Button btn = new Button("Click!");
        btn.Clicked += delegate(object btn, SignalArgs e) {
            Console.WriteLine("Hello World!");
        };

        win.Add(btn);
        win.ShowAll();
        win.Present();

        Utils.GtkMain();
    }
}

/*
    - Signal Handling
    - Packing
    - Subclassing
*/

// STATUS: Presents a window
//
// NEXT STEPS:
//  - Investigate into Glib plumbing
//  - We want to support the following:
//     => Subclassing
//     => Interfaces
//     => Virtual Functions
//     => GType interaction/registration
//
//  - Goals:
//     => To create a easier-to-maintain set of bindings for Gtk
//     => Integration with gobject-introspection
//     => Later on, investigate native C# integrations:
//         -> e.g. System.Drawing, XAML, etc