\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\                                                                             /
\                                T E R M . F S                                /
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

( This file contains the needed words to interact with the terminal and move
  things around it. The terminal size is fixed to 80x24 and shouldn't be
  changed because all the games depend on that same resolution. )

: TERM-HEIGHT ( -- n ) 24 ;
: TERM-WIDTH  ( -- n ) 80 ;

: _TERM-ESCAPE ( -- ) 27 EMIT ." [" ;

: TERM-BEGIN-FORMAT ( -- n ) -1 ;
: TERM-END-FORMAT ( -1 n1 ... -- )
   _TERM-ESCAPE
   BEGIN
   DUP -1 <> WHILE
      0 <# #S #> TYPE
      DUP -1 <> IF
         ." ;"
      THEN
   REPEAT
   DROP
   ." m"
;

: TERM-COLOUR-BLACK   ( -- n ) 0 ;
: TERM-COLOUR-RED     ( -- n ) 1 ;
: TERM-COLOUR-GREEN   ( -- n ) 2 ;
: TERM-COLOUR-YELLOW  ( -- n ) 3 ;
: TERM-COLOUR-BLUE    ( -- n ) 4 ;
: TERM-COLOUR-MAGENTA ( -- n ) 5 ;
: TERM-COLOUR-CYAN    ( -- n ) 6 ;
: TERM-COLOUR-WHITE   ( -- n ) 7 ;

: TERM-FOR-FOREGROUND ( n -- n ) 30 + ;
: TERM-FOR-BACKGROUND ( n -- n ) 40 + ;

: TERM-BOLD  ( -- n ) 1 ;
: TERM-CLEAR ( -- n ) 0 ;

: TERM-CLEAR-FORMAT ( -- )
   TERM-BEGIN-FORMAT
      TERM-CLEAR
   TERM-END-FORMAT
;


: TERM-MOVE-CURSOR-TO ( x y -- )
   _TERM-ESCAPE
   0 <# #S #> TYPE
   ." ;"
   0 <# #S #> TYPE
   ." H"
;
