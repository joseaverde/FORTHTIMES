\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\                                                                             /
\                              P I M P O N . F S                              /
\                                                                             /
\                             F O R T H T I M E S                             /
\                                                                             /
\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\     Copyright (c) 2022  José Antonio Verde Jiménez  All Rights Reserved     /
\ /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/ /
\  This file is part of FORTHTIMES                                            /
\                                                                             /
\  This program is free software:  you  can redistribute it and/or modify it  /
\  under  the terms  of the  GNU  General License  as published by the  Free  /
\  Software  Foundation,  either  version 3  of  the  License,  or  (at your  /
\  opinion) any later version.                                                /
\                                                                             /
\  This  program  is distributed  in the  hope that  it will be  useful, but  /
\  WITHOUT   ANY   WARRANTY;   without   even  the   implied   warranty   of  /
\  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General  /
\  Public License for more details.                                           /
\                                                                             /
\  You should have received  a copy of the  GNU General Public License along  /
\  with this program. If not, see <https://www.gnu.org/licenses/>.            /
\                                                                             /
\ /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/ /

( "Pimpón" or in English Ping-Pong )

s" ../SHARED/TERM.fs" INCLUDED
s" ../SHARED/MATH.fs" INCLUDED
s" FIELD.fs" INCLUDED

: DEFAULT-SIZE ( height width -- ) 18 60 ;

: PIMPON ( height width -- winner 1 or 2 )
   INITIALISE-FIELD
   DRAW-FIELD
;

DEFAULT-SIZE PIMPON BYE
