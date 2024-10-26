M_JMP_IF_NOT_GREATER macro label

		cmp			rcx, r8		
		mov			rax, rcx	
		mov			rcx, rdx	
		sbb			rcx, r9
		jae			label

endm

M_FULL_DIVREM macro d, r

		push		rbx
		push		r12

		not			rcx
		mov			r11, r9
		shld		r11, r8, cl
		mov			r10, rax
		mov			r12, rdx
		xor			rbx, rbx
		sub			rdx, r11
		cmovb		rdx, r12
		sbb			rbx, -1
		div			r11		
		shld		rbx, rax, cl

		mov			r11, r9	
		mov			rax, r8	
		imul		r11, rbx
		mul			rbx
		sub			r10, rax
		sbb			r12, rdx

if r and (not d)
		mov			rax, r10
else
		mov			rax, rbx
endif
if r
		xor			rbx, rbx
endif
		sub			r12, r11
if r
		cmovae		r8, rbx
		cmovae		r9, rbx
	if d
		sbb			rax, rbx
	endif
else 
		sbb			rax, 0
endif
if r
	if r and (not d)
		add			rax, r8
	else
		add			r10, r8
	endif
		adc			r12, r9
	
		mov			r11, [rsp + 56]
	if r and (not d)
		mov			[r11], r12
	else
		mov			[r11], rbx
		mov			[r11 + 8], r10
		mov			[r11 + 16], r12
	endif
endif
	
		pop			r12
		pop			rbx

		ret

endm

.code

;__udivrem128x128
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = quo HI + rem PTR
align 16
a proc public
						
		M_JMP_IF_NOT_GREATER L_CONTINUE__udivrem128x128

		mov			r11, [rsp + 40]
		mov			[r11 + 8], rax
		mov			[r11 + 16], rdx
		xor			rax, rax
		mov			[r11], rax

		ret
	
;__udivrem128x128_rLEl
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = quo HI + rem PTR
align 16
b proc public

		mov			rax, rcx	

L_CONTINUE__udivrem128x128::
		bsr			rcx, r9
		jnz			L_FULL_DIVREM
		mov			r11, [rsp + 40]
		mov			[r11 + 16], r9
		mov			r10, rdx
		cmp			r8, r10 
		mov			rcx, rax
		cmovbe		rax, rdx
		cmovbe		rdx, r9
		div			r8		

		cmp			r8, r10 
		ja			@f
		mov			r9, rax
		mov			rax, rcx
		div			r8
@@:
		mov			[r11], r9
		mov			[r11 + 8], rdx

		ret

b endp
a endp

;__udivrem128x128_rGTu64max
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = 3xu64 PTR: [0] = 0, [2:1] = rem
align 16
c proc public
					
		M_JMP_IF_NOT_GREATER L_CONTINUE__udivrem128x128_rGTu64max

		mov			r11, [rsp + 40]
		mov			[r11 + 8], rax
		mov			[r11 + 16], rdx
		xor			rax, rax

		ret
	
;__udivrem128x128_rGTu64max_rLEl
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = 3xu64 PTR: [0] = 0, [2:1] = rem
align 16
d proc public

		mov			rax, rcx	

L_CONTINUE__udivrem128x128_rGTu64max::
		bsr			rcx, r9
L_FULL_DIVREM::

		M_FULL_DIVREM 1, 1
	
d endp
c endp
	
;__udiv128x128
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = quo HI PTR
align 16
e proc public
					
		M_JMP_IF_NOT_GREATER L_CONTINUE_udiv128x128

		xor 		rax, rax		
		mov			r11, [rsp + 40]	
		mov			[r11], rax	

		ret

;__udiv128x128_rLEl
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = quo HI PTR
align 16
f proc public

		mov			rax, rcx	

L_CONTINUE_udiv128x128::
		mov			r11, [rsp + 40]	
		xor 		r10, r10		
		mov			[r11], r10	

		bsr			rcx, r9
		jnz			L_FULL_DIV
		mov			r10, rdx
		cmp			r8, r10
		mov			rcx, rax
		cmovbe		rax, rdx
		cmovbe		rdx, r9
		div			r8		

		cmp			r8, r10 
		ja			@f
		mov			[r11], rax
		mov			rax, rcx
		div			r8
@@:

		ret
	
f endp
e endp

;__udiv128x128_rGTu64max
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		quo.hi = 0
align 16
g proc public
					
		M_JMP_IF_NOT_GREATER L_CONTINUE_udiv128x128_rGTu64max

		xor			rax, rax

		ret
	
;__udiv128x128_rGTu64max_rLEl
align 16
h proc public	

		mov			rax, rcx	
	
L_CONTINUE_udiv128x128_rGTu64max::
		bsr			rcx, r9
L_FULL_DIV::

		M_FULL_DIVREM 1, 0
	
h endp
g endp

;__urem128x128
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = rem.hi PTR
align 16
i proc public

		mov			r11, [rsp + 40]		

		M_JMP_IF_NOT_GREATER L_CONTINUE_urem128x128

		mov			[r11], rdx

		ret
	
;__urem128x128_rLEl
align 16
j proc public

		mov			rax, rcx				 
		mov			r11, [rsp + 40]		 

L_CONTINUE_urem128x128::
		bsr			rcx, r9
		jnz			L_FULL_REM
		mov			[r11], r9
		mov			r10, rdx
		cmp			r8, r10
		cmovbe		rcx, rax
		cmovbe		rax, rdx
		cmovbe		rdx, r9
		div			r8		

		cmp			r8, r10
		ja			@f
		mov			rax, rcx
		div			r8
@@:
		mov			rax, rdx

		ret

j endp
i endp
	
;__urem128x128_rGTu64max
; rcx = dividend.lo		rdx = dividend.hi		r8 = divisor.lo		r9 = divisor.hi		[rsp + 40] = rem.hi PTR
align 16
k proc public
		
		M_JMP_IF_NOT_GREATER L_CONTINUE_urem128x128_rGTu64max

		mov			r11, [rsp + 40]		
		mov			[r11], rdx

		ret
	
;__urem128x128_rGTu64max_rLEl
align 16
l proc public

		mov			rax, rcx
		
L_CONTINUE_urem128x128_rGTu64max::
		bsr			rcx, r9
L_FULL_REM::
		M_FULL_DIVREM 0, 1

l endp
k endp

end
