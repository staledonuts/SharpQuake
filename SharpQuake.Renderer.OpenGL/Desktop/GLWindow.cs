/// <copyright>
///
/// SharpQuakeEvolved changes by optimus-code, 2019
/// 
/// Based on SharpQuake (Quake Rewritten in C# by Yury Kiselev, 2010.)
///
/// Copyright (C) 1996-1997 Id Software, Inc.
///
/// This program is free software; you can redistribute it and/or
/// modify it under the terms of the GNU General Public License
/// as published by the Free Software Foundation; either version 2
/// of the License, or (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
///
/// See the GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with this program; if not, write to the Free Software
/// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
/// </copyright>

using System;
using System.Drawing;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using SharpQuake.Renderer.Desktop;
using SharpQuake.Framework.IO.Input;
using OpenTK.Mathematics;

namespace SharpQuake.Renderer.OpenGL.Desktop
{
	public class GLWindow : BaseWindow
    {
        private GameWindow OpenTKWindow
        {
            get;
            set;
        }

        private MonitorInfo DisplayDevice
        {
            get;
            set;
        }

        public override VSyncMode VSync
        {

            get
            {
                switch ( OpenTKWindow.VSync )
                {
                    case OpenTK.Windowing.Common.VSyncMode.On:
                        return VSyncMode.One;

                    case OpenTK.Windowing.Common.VSyncMode.Adaptive:
                        return VSyncMode.Other;
                }

                return VSyncMode.None;
            }
            set
            {
                switch ( value )
                {
                    case VSyncMode.One:
                        OpenTKWindow.VSync = OpenTK.Windowing.Common.VSyncMode.On;
                        break;

                    case VSyncMode.None:
                        OpenTKWindow.VSync = OpenTK.Windowing.Common.VSyncMode.Off;
                        break;

                    case VSyncMode.Other:
                        OpenTKWindow.VSync = OpenTK.Windowing.Common.VSyncMode.Adaptive;
                        break;
                }
            }
        }

        public override Icon Icon
        {
            get
            {
                return Icon;
            }
            set
            {
                OpenTKWindow.Icon = value;
            }
        }

        public override Size ClientSize
        {
            get
            {
                return ClientSize;
            }
            set
            {
                //ClientSize = value;
            }
        }

        public override bool IsFullScreen
        {
            get
            {
                return ( OpenTKWindow.WindowState == OpenTK.Windowing.Common.WindowState.Fullscreen );
            }
        }

        public override bool Focused
        {
            get
            {
                return OpenTKWindow.IsFocused;
            }
        }

        public override bool IsMinimised
        {
            get
            {
                return OpenTKWindow.WindowState == OpenTK.Windowing.Common.WindowState.Minimized;
            }
        }

        public override bool CursorVisible
        {
            get
            {
                return OpenTKWindow.CursorVisible;
            }
            set
            {
                OpenTKWindow.CursorVisible = value;
            }
        }

        public override Box2i Bounds
        {
            get
            {
                return OpenTKWindow.Bounds;
            }
            set
            {
                OpenTKWindow.Bounds = value;
            }
        }

        public override bool IsMouseActive
        {
            get
            {
                return ( OpenTKWindow.MouseState.( 0 ).IsConnected != false );
            }
        }

        public GLWindow( String title, Size size, bool isFullScreen ) : base( title, size, isFullScreen )
        {
            //Workaround for SDL2 mouse input issues
            var options = new OpenTK.ToolkitOptions( );
            options.Backend = OpenTK.Windowing.Desktop.NativeWindowSettings.PreferNative;
            options.EnableHighResolution = true; //Just for testing
            OpenTK.Toolkit.Init( options );

            // select display device
            DisplayDevice = Monitors.GetPrimaryMonitor();

            OpenTKWindow = new GameWindow( new(1, 1, 0), new() /*size.Width, size.Height, new OpenTK.Graphics.OpenGL.GraphicsMode( ), title, isFullScreen ? OpenTK.Windowing.Common.WindowState.Fullscreen : NativeWindowSettings.Default */);
            
            RouteEvents( );

            Device = new GLDevice( OpenTKWindow, DisplayDevice );
        }

        public override void RouteEvents( )
        {
            OpenTKWindow.FocusedChanged += ( sender, args ) =>
            {
                OnFocusedChanged( );
            };

            OpenTKWindow.Closing += ( sender, args ) =>
            {
                OnClosing( );
            };

            OpenTKWindow.UpdateFrame += ( sender, args ) =>
            {
                OnUpdateFrame( args.Time );
            };

            OpenTKWindow.KeyDown += ( sender, args ) =>
            {
                KeyDown?.Invoke( sender, new KeyboardKeyEventArgs( ( Key ) ( Int32 ) args.Key ) );
            };

            OpenTKWindow.KeyUp += ( sender, args ) =>
            {
                KeyUp?.Invoke( sender, new KeyboardKeyEventArgs( ( Key ) ( Int32 ) args.Key ) );
            };

            OpenTKWindow.MouseMove += ( sender, args ) =>
            {
                MouseMove?.Invoke( sender, new EventArgs( ) );
            };

            OpenTKWindow.MouseDown += ( sender, args ) =>
            {
                MouseDown?.Invoke( sender, new MouseButtonEventArgs( ( MouseButton ) ( Int32 ) args.Button, args.IsPressed ) );
            };

            OpenTKWindow.MouseUp += ( sender, args ) =>
            {
                MouseUp?.Invoke( sender, new MouseButtonEventArgs( ( MouseButton ) ( Int32 ) args.Button, args.IsPressed ) );
            };

            OpenTKWindow.MouseWheel += ( sender, args ) =>
            {
                MouseWheel?.Invoke( sender, new MouseWheelEventArgs( args.Delta ) );
            };
        }

        public override void Run( )
        {
            OpenTKWindow.Run( );
        }

        protected override void OnFocusedChanged( )
        {
            //throw new NotImplementedException( );
        }

        protected override void OnClosing( )
        {
            //throw new NotImplementedException( );
        }

        protected override void OnUpdateFrame( Double Time )
        {
            //throw new NotImplementedException( );
        }

        public override void Present( )
        {
            OpenTKWindow.SwapBuffers( );
        }

        public override void SetFullScreen( bool isFullScreen )
        {
            if ( isFullScreen )
            {
                OpenTKWindow.WindowState = OpenTK.WindowState.Fullscreen;
                OpenTKWindow.WindowBorder = OpenTK.WindowBorder.Hidden;
            }
            else
            {
                OpenTKWindow.WindowState = OpenTK.WindowState.Normal;
                OpenTKWindow.WindowBorder = OpenTK.WindowBorder.Fixed;
            }
        }


        public override void ProcessEvents( )
        {
            OpenTKWindow.ProcessEvents( );
        }

        public override void Exit( )
        {
            OpenTKWindow.Close( );
        }

        public override void SetMousePosition( Int32 x, Int32 y )
        {
            OpenTKWindow.MousePosition.Yx = new( x, y );
        }

        public override Point GetMousePosition( )
        {
            return new Point( (int)OpenTKWindow.MousePosition.X, (int)OpenTKWindow.MousePosition.Y);
        }

        public override void Dispose( )
        {
            base.Dispose( );

            OpenTKWindow.Dispose( );

            IsDisposed = true;
        }
    }
}
