\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\                                                                             /
\                                M A T H . F S                                /
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

( This file declares operations for fixed-point math, the word FIXED-FLOAT
  is declared and contains the number by which the number must be divided to
  get the real value of the number. Numbers use just one cell. If you see f in
  function declarations it means fixed-point number, otherwise it is an
  integer )

: FIXED-FLOAT 10000 ;
: PI 31415926535 FIXED-FLOAT 10000000000 */ ;

: FIXED-SQUARED FIXED-FLOAT FIXED-FLOAT * ;

: ^ ( f e -- f^e )
   DUP 0< IF
      -1 * RECURSE FIXED-SQUARED SWAP /
   ELSE DUP 0 = IF
      2DROP
      1
   ELSE DUP 1 = IF
      DROP
   ELSE
      FIXED-FLOAT    \ 1.00000
      SWAP
      0 DO
         OVER FIXED-FLOAT */
      LOOP
      SWAP DROP
   THEN THEN THEN
;

\ Radians go from -PI to PI
: RADIANS ( f -- f )
   360 FIXED-FLOAT * MOD DUP
   PI 180 FIXED-FLOAT * */
   PI -
;
