include Irvine32.inc

.data

game db '_','_','_'
g_size = ($ - game)
     db '_','_','_'
	 db '_','_','_'

r_ind DD 0
c_ind DD 0
turn db '1'
get_X db "Enter x: ",0
get_Y db "Enter y: ",0
whose_turn db "Your Turn",0
winnerP db "Congratulations! You Won! ",0
winnerC db "You Lost! Better luck next time :-)",0
draw db "Its a DRAW!!!",0
occupied db "This Place is already Occupied!",0
mes db "Index out of bound!!",0
play_again db "Play again?(y/n)",0
count DD 0

.code
main proc

call Randomize

Play:

call Initialize_Game
call clrscr

call Display_Grid
call crlf

mov ecx,9

GAME_MAIN:

push ecx

mov edx,offset whose_turn
call writestring
mov al,turn
call crlf

cmp al,'1'
JE P

call Attack
JECXZ Defend
JMP ABC

Defend:
call Comp_XY
JMP ABC

P:
call INPUT

ABC:
call crlf

call Make_Move

call clrscr
call Display_Grid
call crlf

call WIN

JECXZ WINNER_ANNOUNCEMENT

Call Change_Player

pop ecx

LOOP GAME_MAIN

mov edx,offset draw
call writestring
JMP E

WINNER_ANNOUNCEMENT:
mov al,turn
cmp al,'1'
JE PWIN
mov edx,offset winnerC
JMP Declare_WINNER
PWIN:
mov edx,offset winnerP

Declare_WINNER:
call writeString

E:
call crlf
mov edx,offset play_again
call writestring
call readchar
call writechar

cmp al,'y'
JE Play

call crlf
call waitmsg
exit
main endp


;*******************************PROCEDURES***************************

Initialize_Game PROC 
call crlf
mov dl,'1'
mov turn,dl

mov ecx,9
mov edi,offset game
mov dl,'_'

Initialize:

mov [edi],dl
inc edi

LOOP Initialize
ret 
Initialize_Game endp

INPUT PROC

mov ecx,10

Valid:

mov edx,offset get_X
call writestring
call readDec
mov r_ind,eax 
mov eax,2
cmp eax,r_ind
jb L1
jmp L2
L1:
mov edx,OFFSET mes
call WriteString
jmp Valid
L2:
mov edx,offset get_Y
call writestring
call readDec 
mov c_ind,eax
mov eax,2
cmp eax,c_ind
jb col1
jmp col2
col1:
jmp L2
col2:
Call Check_Validity

LOOPNZ Valid 

ret
INPUT endp

Display_Grid PROC

mov esi,0
mov ecx,g_size
mov bl,'0'

mov al,' '
call WriteChar

L: ;Display Column Number
mov al,' '
call WriteChar

mov al,bl
call WriteChar
inc bl
LOOP L

mov bl,'0'
mov ecx,g_size
call crlf

L1: 
push ecx
mov ecx,g_size

mov al,bl
call WriteChar
mov al,' '
call WriteChar

L2:

mov al,game[esi]
call WriteChar
mov al,' '
call WriteChar
inc esi

LOOP L2

inc bl ;Display next row number
call CRLF 
pop ecx
LOOP L1

ret 
Display_Grid endp


;*********************************************Make_Move*****************************


Make_Move PROC

mov eax,r_ind
mov ebx,g_size
mul ebx
mov esi,c_ind

mov dl,turn

cmp dl, 31h

JE Player1
mov game[eax+esi],'X' ;if player 2's turn then mark X
JMP MOVE

Player1:
mov game[eax+esi],'O' ;if player 1's turn then mark O

MOVE:
ret
Make_Move endp


;*********************************************Change_Player*****************************


Change_Player PROC 
mov al,turn

cmp al, 31h
JE SWITCH2
dec turn
JMP BYE

SWITCH2:
inc turn

BYE:
ret
Change_Player endp


;*********************************************WIN*****************************


WIN PROC

mov ecx,2

mov esi,offset game
add esi,c_ind

mov dl,[esi]
cmp dl,'_'
JE Row_Comparison

Check_Column:

add esi,3
mov bl,[esi]
cmp bl,'_'
JE Row_Comparison
cmp dl,[esi]

JNZ Row_Comparison

LOOP Check_Column

JMP GAME_END

Row_Comparison:
mov ecx,2
mov esi,offset game

mov eax,3
mov ebx,r_ind
mul ebx

add esi,eax

mov dl,[esi]

Check_Row:

inc esi
mov bl,[esi]
cmp bl,'_'
JE Left_Diagnol_Comparison

cmp dl,[esi]
JNZ Left_Diagnol_Comparison

LOOP Check_Row

JMP GAME_END

Left_Diagnol_Comparison:
mov ecx,2
mov esi,offset game

mov dl,[esi]

cmp dl,'_'
JNE Left
JMP Right_Diagnol_Comparison

Left:
add esi,4
mov bl,[esi]
cmp bl,'_'
JE Right_Diagnol_Comparison
cmp dl,[esi]
JNZ Right_Diagnol_Comparison
LOOP Left

JMP GAME_END

Right_Diagnol_Comparison:
mov ecx,2
mov esi,offset game + 2

mov dl,[esi]

cmp dl,'_'
JNE Right
JMP GAME_END

Right:
add esi,2
mov bl,[esi]
cmp bl,'_'
JE GAME_END
cmp dl,[esi]
JNZ GAME_END

LOOP Right

GAME_END:
ret
WIN endp


;*********************************************Check_Validity*****************************


Check_Validity PROC

mov eax,r_ind
mov ebx,g_size
mul ebx
mov esi,c_ind

mov dl,game[esi+eax]

cmp dl,'_'

JNE ERROR
JMP OK

ERROR:
mov edx,offset occupied
call writestring
call crlf

OK:
ret
Check_Validity endp


;*********************************************Comp_XY*****************************


Comp_XY PROC

mov esi,offset game
mov ecx,9
call Change_Player

L:
mov edi,esi
mov dl,[esi]
cmp dl,'_'
JE Check_Move

JMP A

Check_Move:
Call R_C

mov count,ecx
call Make_Move
call Win

mov dl,'_'
mov [edi],dl
JECXZ XYZ
mov ecx,count

A:
mov esi,edi
inc esi
LOOP L

Random_XY:

mov eax,9
call RandomRange
mov r_ind,eax

mov eax,9
call RandomRange
mov c_ind,eax

mov eax,r_ind
mov ebx,3
mul ebx
mov esi,c_ind

mov dl,game[eax+esi]
cmp dl,'_'
JNE Random_XY

XYZ:
call Change_Player

ret
Comp_XY endp


;*********************************************R_C*****************************

R_C PROC 

mov ebx,3
mov edx,offset game
sub esi,edx
mov edx,0
mov eax,esi
div ebx
mov r_ind,eax
mov c_ind,edx

ret
R_C endp


;*********************************************Attack*****************************


Attack PROC

mov esi,offset game
mov ecx,9

WIN_TRY:
mov count,ecx
mov edi,esi
mov dl,[esi]
cmp dl,'_'
JNE B

Check_MoveW:
Call R_C

call Make_Move
call Win

mov dl,'_'
mov [edi],dl
JECXZ JKL

B:
mov ecx,count
mov esi,edi
inc esi
LOOP WIN_TRY

JKL:
ret
Attack endp

end main

