\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\                                                                             /
\                               F I E L D . F S                               /
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

\ The field: (height)(width)
VARIABLE FIELD 1 CELLS ALLOT

: INITIALISE-FIELD ( height width -- )
   FIELD 1 CELLS + !
   FIELD !
;

: DRAW-FIELD ( -- )
   TERM-BEGIN-FORMAT
      TERM-COLOUR-BLACK TERM-FOR-BACKGROUND
      TERM-COLOUR-WHITE TERM-FOR-FOREGROUND
   TERM-END-FORMAT
   \ Top
   2 0 TERM-MOVE-CURSOR-TO
   ." ┌"
   FIELD 1 CELLS + @ 2 - 2 DO
      ." ─"
   LOOP
   ." ┐"
   \ Bottom
   2 FIELD @ TERM-MOVE-CURSOR-TO
   ." └"
   FIELD 1 CELLS + @ 2 - 2 DO
      ." ─"
   LOOP
   ." ┘"
   TERM-CLEAR-FORMAT
;

: CLEAR-FIELD ( -- )
   TERM-BEGIN-FORMAT
      TERM-COLOUR-BLACK TERM-FOR-BACKGROUND
      TERM-COLOUR-BLACK TERM-FOR-FOREGROUND
   TERM-END-FORMAT

   FIELD @ 0 DO
      FIELD 1 CELLS + @ 0 DO
         ."  "
      LOOP
      CR
   LOOP

   TERM-CLEAR-FORMAT
;
