/// <copyright>
///
/// SharpQuakeEvolved changes by optimus-code, 2019
/// 
/// Based on SharpQuake Rewritten in C# by Yury Kiselev, 2010.
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

using System.Drawing;
using OpenTK;
using OpenTK.Input;
using SharpQuake.Framework;

// input.h -- external (non-keyboard) input devices

namespace SharpQuake
{
    /// <summary>
    /// In_functions
    /// </summary>
    public class Input
    {
        public System.Boolean IsMouseActive
        {
            get
            {
                return _IsMouseActive;
            }
        }

        public Point WindowCenter
        {
            get
            {
                var bounds = MainWindow.Instance.Bounds;
                var p = bounds.Location;
                p.Offset( bounds.Width / 2, bounds.Height / 2 );
                return p;
            }
        }

        private CVar _MouseFilter;// = { "m_filter", "0" };
        private Vector2 _OldMouse; // old_mouse_x, old_mouse_y
        private Vector2 _Mouse; // mouse_x, mouse_y
        private Vector2 _MouseAccum; // mx_accum, my_accum
        private System.Boolean _IsMouseActive; // mouseactive
        private System.Int32 _MouseButtons; // mouse_buttons
        private System.Int32 _MouseOldButtonState; // mouse_oldbuttonstate
        private System.Boolean _MouseActivateToggle; // mouseactivatetoggle
        private System.Boolean _MouseShowToggle = true; // mouseshowtoggle

        // Instances
        private static Host Host
        {
            get;
            set;
        }

        // IN_Init
        public void Initialise( Host host )
        {
            Host = host;

            if ( _MouseFilter == null )
            {
                _MouseFilter = new CVar( "m_filter", "0" );
            }

            _IsMouseActive = ( Mouse.GetState( 0 ).IsConnected != false );
            if( _IsMouseActive )
            {
                _MouseButtons = 3; //??? TODO: properly upgrade this to 3.0.1
            }
        }

        /// <summary>
        /// IN_Shutdown
        /// </summary>
        public void Shutdown()
        {
            DeactivateMouse();
            ShowMouse();
        }

        // IN_Commands
        // oportunity for devices to stick commands on the script buffer
        public void Commands()
        {
            // joystick not supported
        }

        /// <summary>
        /// IN_ActivateMouse
        /// </summary>
        public void ActivateMouse()
        {
            _MouseActivateToggle = true;

            if( Mouse.GetState( 0 ).IsConnected != false )
            {
                //if (mouseparmsvalid)
                //    restore_spi = SystemParametersInfo (SPI_SETMOUSE, 0, newmouseparms, 0);

                //Cursor.Position = Input.WindowCenter;
                Mouse.SetPosition(WindowCenter.X, WindowCenter.Y);


                //SetCapture(mainwindow);

                //Cursor.Clip = MainWindow.Instance.Bounds;

                _IsMouseActive = true;
            }
        }

        /// <summary>
        /// IN_DeactivateMouse
        /// </summary>
        public void DeactivateMouse()
        {
            _MouseActivateToggle = false;

            //Cursor.Clip = Screen.PrimaryScreen.Bounds;

            _IsMouseActive = false;
        }

        /// <summary>
        /// IN_HideMouse
        /// </summary>
        public void HideMouse()
        {
            if( _MouseShowToggle )
            {
                //Cursor.Hide();
                _MouseShowToggle = false;
            }
        }

        /// <summary>
        /// IN_ShowMouse
        /// </summary>
        public void ShowMouse()
        {
            if( !_MouseShowToggle )
            {
                if( !MainWindow.IsFullscreen )
                {
                    //Cursor.Show();
                }
                _MouseShowToggle = true;
            }
        }

        // IN_Move
        // add additional movement on top of the keyboard move cmd
        public void Move( usercmd_t cmd )
        {
            if( !MainWindow.Instance.Focused )
                return;

            if( MainWindow.Instance.WindowState == WindowState.Minimized )
                return;

            MouseMove( cmd );
        }

        // IN_ClearStates
        // restores all button and position states to defaults
        public void ClearStates()
        {
            if( _IsMouseActive )
            {
                _MouseAccum = Vector2.Zero;
                _MouseOldButtonState = 0;
            }
        }

        /// <summary>
        /// IN_MouseEvent
        /// </summary>
        public void MouseEvent( System.Int32 mstate )
        {
            if( _IsMouseActive )
            {
                // perform button actions
                for( var i = 0; i < _MouseButtons; i++ )
                {
                    if( ( mstate & ( 1 << i ) ) != 0 && ( _MouseOldButtonState & ( 1 << i ) ) == 0 )
                    {
                        Host.Keyboard.Event( KeysDef.K_MOUSE1 + i, true );
                    }

                    if( ( mstate & ( 1 << i ) ) == 0 && ( _MouseOldButtonState & ( 1 << i ) ) != 0 )
                    {
                        Host.Keyboard.Event( KeysDef.K_MOUSE1 + i, false );
                    }
                }

                _MouseOldButtonState = mstate;
            }
        }

        /// <summary>
        /// IN_MouseMove
        /// </summary>
        private void MouseMove( usercmd_t cmd )
        {
            if( !_IsMouseActive )
                return;
           
            var current_pos = new Point(Mouse.GetCursorState().X, Mouse.GetCursorState().Y); //Cursor.Position;
            var window_center = WindowCenter;

            var mx = ( System.Int32 ) ( current_pos.X - window_center.X + _MouseAccum.X );
            var my = ( System.Int32 ) ( current_pos.Y - window_center.Y + _MouseAccum.Y );
            _MouseAccum.X = 0;
            _MouseAccum.Y = 0;

            if( _MouseFilter.Value != 0 )
            {
                _Mouse.X = ( mx + _OldMouse.X ) * 0.5f;
                _Mouse.Y = ( my + _OldMouse.Y ) * 0.5f;
            }
            else
            {
                _Mouse.X = mx;
                _Mouse.Y = my;
            }

            _OldMouse.X = mx;
            _OldMouse.Y = my;

            _Mouse *= Host.Client.Sensitivity;

            // add mouse X/Y movement to cmd
            if( client_input.StrafeBtn.IsDown || ( Host.Client.LookStrafe && client_input.MLookBtn.IsDown ) )
                cmd.sidemove += Host.Client.MSide * _Mouse.X;
            else
                Host.Client.cl.viewangles.Y -= Host.Client.MYaw * _Mouse.X;

            Host.View.StopPitchDrift();

            Host.Client.cl.viewangles.X += Host.Client.MPitch * _Mouse.Y;

            // modernized to always use mouse look
            Host.Client.cl.viewangles.X = MathHelper.Clamp( Host.Client.cl.viewangles.X, -70, 80 );

            // if the mouse has moved, force it to the center, so there's room to move
            if( mx != 0 || my != 0 )
            {
                //Cursor.Position = window_center;
                Mouse.SetPosition(window_center.X, window_center.Y);
            }
        }
    }
}
