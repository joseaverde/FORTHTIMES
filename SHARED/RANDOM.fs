\ \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\ /
\                                                                             /
\                              R A N D O M . F S                              /
\                                                                             /
\                             F O R T H T I M E S                             /
\                                                                             /
\ /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/ /

\ Source <https://groups.google.com/g/comp.lang.forth/c/4hOqv2m8wA4>

VARIABLE (GENERATOR) \ seed
UTIME DROP (GENERATOR) !

: RANDOM ( -- x )
   (GENERATOR) @
   DUP 13 LSHIFT XOR
   DUP 17 RSHIFT XOR
   DUP  5 LSHIFT XOR
   (GENERATOR) !
   (GENERATOR) @
;
