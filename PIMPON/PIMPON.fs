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
s" PAD.fs" INCLUDED
s" BALL.fs" INCLUDED

: DEFAULT-SIZE ( height width -- ) 18 60 ;

VARIABLE LEFT PAD-SIZE ALLOT
VARIABLE RIGHT PAD-SIZE ALLOT
VARIABLE FRAME-COUNT 0 FRAME-COUNT !

: FPS 60 ;

: DELAY 1000 FPS / MS ;

: PIMPON-GAME-LOOP ( -- winner )
   FALSE BEGIN
      LEFT PAD.SHOW
      RIGHT PAD.SHOW
      KEY? IF
         KEY CASE
            [char] w OF LEFT -1 PAD.MOVE ENDOF
            [char] s OF LEFT  1 PAD.MOVE ENDOF
            [char] q OF      INVERT      ENDOF
         ENDCASE
      THEN
      0 0 TERM-MOVE-CURSOR-TO
      DELAY
      1 FRAME-COUNT +!
   DUP UNTIL
   DROP
   \ Who wins?
   LEFT 4 CELLS + @ RIGHT 4 CELLS + @ < IF
      1
   ELSE
      2
   THEN
;

: PIMPON ( height width -- winner 1 or 2 )
   PAGE
   INITIALISE-FIELD
   CLEAR-FIELD
   DRAW-FIELD
   LEFT 1 TERM-COLOUR-RED PAD.INITIALISE
   RIGHT 2 TERM-COLOUR-GREEN PAD.INITIALISE
   PIMPON-GAME-LOOP
   PAGE
;

DEFAULT-SIZE PIMPON BYE
