\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\                                                                             /
\                                 P A D . F S                                 /
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

\ The pad contains:
\  (length)
\  (x position) Multiplied by fixed-float
\  (y position) Multiplied by fixed-float
\  (colour)
\  (points)
: PAD-SIZE 5 1- CELLS ;
: PAD-LENGTH 3 ;

: PAD.INITIALISE ( pad-addr player colour -- )
   SWAP >R
   \ PAD.COLOUR = COLOUR
   OVER 3 CELLS + !
   R> 1 = IF
      \ Player 1 : PAD.X = 1
      DUP 1 CELLS + 2 FIXED-FLOAT * SWAP !
   ELSE
      \ Player 2 : PAD.X = PAD.WIDTH - 1
      DUP 1 CELLS +
      FIELD 1 CELLS + @ 2 - FIXED-FLOAT * SWAP !
   THEN
   \ PAD.Y = FIELD.HEIGHT/2 + 1
   DUP 2 CELLS + FIELD @ 2 / 1 + FIXED-FLOAT * SWAP !
   \ PAD.POINTS = 0
   DUP 4 CELLS + 0 SWAP !
   \ PAD.LENGTH = PAD-LENGTH
   PAD-LENGTH SWAP !
;


: PAD.SHOW ( pad-addr -- )
   TERM-BEGIN-FORMAT
      OVER 3 CELLS + @ DUP TERM-FOR-BACKGROUND
      SWAP TERM-FOR-FOREGROUND
   TERM-END-FORMAT
   DUP 1 CELLS + @ FIXED-FLOAT / SWAP
   DUP 2 CELLS + @ FIXED-FLOAT / SWAP
   @ 1 DO
      2DUP I + TERM-MOVE-CURSOR-TO
      ." █"
   LOOP
   TERM-CLEAR-FORMAT
   2DROP
;


: PAD.MOVE ( amount pad-addr -- )
   \ Clear
   OVER 3 CELLS + @ >R
   OVER 3 CELLS + 0 SWAP !
   OVER PAD.SHOW
   OVER 3 CELLS + R> SWAP !

   SWAP 2 CELLS +
   SWAP FIXED-FLOAT * SWAP +!
;
