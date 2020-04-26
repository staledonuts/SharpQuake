﻿/// <copyright>
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpQuake.Framework.Mathematics;

namespace SharpQuake.Framework.Definitions
{
	public static class anorms
	{
		public const System.Int32 NUMVERTEXNORMALS = 162;

		public static readonly Vector3[] Values = new Vector3[NUMVERTEXNORMALS]
		{
			new Vector3(-0.525731f, 0.000000f, 0.850651f),
			new Vector3(-0.442863f, 0.238856f, 0.864188f),
			new Vector3(-0.295242f, 0.000000f, 0.955423f),
			new Vector3(-0.309017f, 0.500000f, 0.809017f),
			new Vector3(-0.162460f, 0.262866f, 0.951056f),
			new Vector3(0.000000f, 0.000000f, 1.000000f),
			new Vector3(0.000000f, 0.850651f, 0.525731f),
			new Vector3(-0.147621f, 0.716567f, 0.681718f),
			new Vector3(0.147621f, 0.716567f, 0.681718f),
			new Vector3(0.000000f, 0.525731f, 0.850651f),
			new Vector3(0.309017f, 0.500000f, 0.809017f),
			new Vector3(0.525731f, 0.000000f, 0.850651f),
			new Vector3(0.295242f, 0.000000f, 0.955423f),
			new Vector3(0.442863f, 0.238856f, 0.864188f),
			new Vector3(0.162460f, 0.262866f, 0.951056f),
			new Vector3(-0.681718f, 0.147621f, 0.716567f),
			new Vector3(-0.809017f, 0.309017f, 0.500000f),
			new Vector3(-0.587785f, 0.425325f, 0.688191f),
			new Vector3(-0.850651f, 0.525731f, 0.000000f),
			new Vector3(-0.864188f, 0.442863f, 0.238856f),
			new Vector3(-0.716567f, 0.681718f, 0.147621f),
			new Vector3(-0.688191f, 0.587785f, 0.425325f),
			new Vector3(-0.500000f, 0.809017f, 0.309017f),
			new Vector3(-0.238856f, 0.864188f, 0.442863f),
			new Vector3(-0.425325f, 0.688191f, 0.587785f),
			new Vector3(-0.716567f, 0.681718f, -0.147621f),
			new Vector3(-0.500000f, 0.809017f, -0.309017f),
			new Vector3(-0.525731f, 0.850651f, 0.000000f),
			new Vector3(0.000000f, 0.850651f, -0.525731f),
			new Vector3(-0.238856f, 0.864188f, -0.442863f),
			new Vector3(0.000000f, 0.955423f, -0.295242f),
			new Vector3(-0.262866f, 0.951056f, -0.162460f),
			new Vector3(0.000000f, 1.000000f, 0.000000f),
			new Vector3(0.000000f, 0.955423f, 0.295242f),
			new Vector3(-0.262866f, 0.951056f, 0.162460f),
			new Vector3(0.238856f, 0.864188f, 0.442863f),
			new Vector3(0.262866f, 0.951056f, 0.162460f),
			new Vector3(0.500000f, 0.809017f, 0.309017f),
			new Vector3(0.238856f, 0.864188f, -0.442863f),
			new Vector3(0.262866f, 0.951056f, -0.162460f),
			new Vector3(0.500000f, 0.809017f, -0.309017f),
			new Vector3(0.850651f, 0.525731f, 0.000000f),
			new Vector3(0.716567f, 0.681718f, 0.147621f),
			new Vector3(0.716567f, 0.681718f, -0.147621f),
			new Vector3(0.525731f, 0.850651f, 0.000000f),
			new Vector3(0.425325f, 0.688191f, 0.587785f),
			new Vector3(0.864188f, 0.442863f, 0.238856f),
			new Vector3(0.688191f, 0.587785f, 0.425325f),
			new Vector3(0.809017f, 0.309017f, 0.500000f),
			new Vector3(0.681718f, 0.147621f, 0.716567f),
			new Vector3(0.587785f, 0.425325f, 0.688191f),
			new Vector3(0.955423f, 0.295242f, 0.000000f),
			new Vector3(1.000000f, 0.000000f, 0.000000f),
			new Vector3(0.951056f, 0.162460f, 0.262866f),
			new Vector3(0.850651f, -0.525731f, 0.000000f),
			new Vector3(0.955423f, -0.295242f, 0.000000f),
			new Vector3(0.864188f, -0.442863f, 0.238856f),
			new Vector3(0.951056f, -0.162460f, 0.262866f),
			new Vector3(0.809017f, -0.309017f, 0.500000f),
			new Vector3(0.681718f, -0.147621f, 0.716567f),
			new Vector3(0.850651f, 0.000000f, 0.525731f),
			new Vector3(0.864188f, 0.442863f, -0.238856f),
			new Vector3(0.809017f, 0.309017f, -0.500000f),
			new Vector3(0.951056f, 0.162460f, -0.262866f),
			new Vector3(0.525731f, 0.000000f, -0.850651f),
			new Vector3(0.681718f, 0.147621f, -0.716567f),
			new Vector3(0.681718f, -0.147621f, -0.716567f),
			new Vector3(0.850651f, 0.000000f, -0.525731f),
			new Vector3(0.809017f, -0.309017f, -0.500000f),
			new Vector3(0.864188f, -0.442863f, -0.238856f),
			new Vector3(0.951056f, -0.162460f, -0.262866f),
			new Vector3(0.147621f, 0.716567f, -0.681718f),
			new Vector3(0.309017f, 0.500000f, -0.809017f),
			new Vector3(0.425325f, 0.688191f, -0.587785f),
			new Vector3(0.442863f, 0.238856f, -0.864188f),
			new Vector3(0.587785f, 0.425325f, -0.688191f),
			new Vector3(0.688191f, 0.587785f, -0.425325f),
			new Vector3(-0.147621f, 0.716567f, -0.681718f),
			new Vector3(-0.309017f, 0.500000f, -0.809017f),
			new Vector3(0.000000f, 0.525731f, -0.850651f),
			new Vector3(-0.525731f, 0.000000f, -0.850651f),
			new Vector3(-0.442863f, 0.238856f, -0.864188f),
			new Vector3(-0.295242f, 0.000000f, -0.955423f),
			new Vector3(-0.162460f, 0.262866f, -0.951056f),
			new Vector3(0.000000f, 0.000000f, -1.000000f),
			new Vector3(0.295242f, 0.000000f, -0.955423f),
			new Vector3(0.162460f, 0.262866f, -0.951056f),
			new Vector3(-0.442863f, -0.238856f, -0.864188f),
			new Vector3(-0.309017f, -0.500000f, -0.809017f),
			new Vector3(-0.162460f, -0.262866f, -0.951056f),
			new Vector3(0.000000f, -0.850651f, -0.525731f),
			new Vector3(-0.147621f, -0.716567f, -0.681718f),
			new Vector3(0.147621f, -0.716567f, -0.681718f),
			new Vector3(0.000000f, -0.525731f, -0.850651f),
			new Vector3(0.309017f, -0.500000f, -0.809017f),
			new Vector3(0.442863f, -0.238856f, -0.864188f),
			new Vector3(0.162460f, -0.262866f, -0.951056f),
			new Vector3(0.238856f, -0.864188f, -0.442863f),
			new Vector3(0.500000f, -0.809017f, -0.309017f),
			new Vector3(0.425325f, -0.688191f, -0.587785f),
			new Vector3(0.716567f, -0.681718f, -0.147621f),
			new Vector3(0.688191f, -0.587785f, -0.425325f),
			new Vector3(0.587785f, -0.425325f, -0.688191f),
			new Vector3(0.000000f, -0.955423f, -0.295242f),
			new Vector3(0.000000f, -1.000000f, 0.000000f),
			new Vector3(0.262866f, -0.951056f, -0.162460f),
			new Vector3(0.000000f, -0.850651f, 0.525731f),
			new Vector3(0.000000f, -0.955423f, 0.295242f),
			new Vector3(0.238856f, -0.864188f, 0.442863f),
			new Vector3(0.262866f, -0.951056f, 0.162460f),
			new Vector3(0.500000f, -0.809017f, 0.309017f),
			new Vector3(0.716567f, -0.681718f, 0.147621f),
			new Vector3(0.525731f, -0.850651f, 0.000000f),
			new Vector3(-0.238856f, -0.864188f, -0.442863f),
			new Vector3(-0.500000f, -0.809017f, -0.309017f),
			new Vector3(-0.262866f, -0.951056f, -0.162460f),
			new Vector3(-0.850651f, -0.525731f, 0.000000f),
			new Vector3(-0.716567f, -0.681718f, -0.147621f),
			new Vector3(-0.716567f, -0.681718f, 0.147621f),
			new Vector3(-0.525731f, -0.850651f, 0.000000f),
			new Vector3(-0.500000f, -0.809017f, 0.309017f),
			new Vector3(-0.238856f, -0.864188f, 0.442863f),
			new Vector3(-0.262866f, -0.951056f, 0.162460f),
			new Vector3(-0.864188f, -0.442863f, 0.238856f),
			new Vector3(-0.809017f, -0.309017f, 0.500000f),
			new Vector3(-0.688191f, -0.587785f, 0.425325f),
			new Vector3(-0.681718f, -0.147621f, 0.716567f),
			new Vector3(-0.442863f, -0.238856f, 0.864188f),
			new Vector3(-0.587785f, -0.425325f, 0.688191f),
			new Vector3(-0.309017f, -0.500000f, 0.809017f),
			new Vector3(-0.147621f, -0.716567f, 0.681718f),
			new Vector3(-0.425325f, -0.688191f, 0.587785f),
			new Vector3(-0.162460f, -0.262866f, 0.951056f),
			new Vector3(0.442863f, -0.238856f, 0.864188f),
			new Vector3(0.162460f, -0.262866f, 0.951056f),
			new Vector3(0.309017f, -0.500000f, 0.809017f),
			new Vector3(0.147621f, -0.716567f, 0.681718f),
			new Vector3(0.000000f, -0.525731f, 0.850651f),
			new Vector3(0.425325f, -0.688191f, 0.587785f),
			new Vector3(0.587785f, -0.425325f, 0.688191f),
			new Vector3(0.688191f, -0.587785f, 0.425325f),
			new Vector3(-0.955423f, 0.295242f, 0.000000f),
			new Vector3(-0.951056f, 0.162460f, 0.262866f),
			new Vector3(-1.000000f, 0.000000f, 0.000000f),
			new Vector3(-0.850651f, 0.000000f, 0.525731f),
			new Vector3(-0.955423f, -0.295242f, 0.000000f),
			new Vector3(-0.951056f, -0.162460f, 0.262866f),
			new Vector3(-0.864188f, 0.442863f, -0.238856f),
			new Vector3(-0.951056f, 0.162460f, -0.262866f),
			new Vector3(-0.809017f, 0.309017f, -0.500000f),
			new Vector3(-0.864188f, -0.442863f, -0.238856f),
			new Vector3(-0.951056f, -0.162460f, -0.262866f),
			new Vector3(-0.809017f, -0.309017f, -0.500000f),
			new Vector3(-0.681718f, 0.147621f, -0.716567f),
			new Vector3(-0.681718f, -0.147621f, -0.716567f),
			new Vector3(-0.850651f, 0.000000f, -0.525731f),
			new Vector3(-0.688191f, 0.587785f, -0.425325f),
			new Vector3(-0.587785f, 0.425325f, -0.688191f),
			new Vector3(-0.425325f, 0.688191f, -0.587785f),
			new Vector3(-0.425325f, -0.688191f, -0.587785f),
			new Vector3(-0.587785f, -0.425325f, -0.688191f),
			new Vector3(-0.688191f, -0.587785f, -0.425325f)
		};
	}
}
