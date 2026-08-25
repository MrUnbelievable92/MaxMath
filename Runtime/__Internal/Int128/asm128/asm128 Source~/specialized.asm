M_MAIN_UDIV_MAX_128x64_INC macro divisor

        mov         rax, -1
        xor         edx, edx
        div         divisor
        mov         r11, rax
        mov         rax, -1
        div         divisor
        add         rax, 1
        adc         r11, 0
    
endm

M_MAIN_UDIV_128hiXloRlo macro hi64, divisor

        mov         rdx, hi64
        xor         eax, eax 
        div         divisor
        mov         hi64, rax
    
endm

.code

;__spc__4xudivmax128x64_inc
;rcx: div0,      rdx: div2,     r8 result PTR       r9 div3,    [rsp + 40]: div4
align 16
v proc public

        mov         r10, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx
        
        mov         [r8], rax
        mov         [r8 + 8], r11

        add         r8, 16
        mov         rcx, r10
        mov         rdx, r9
        mov         r9, [rsp + 40]
    
;__spc__3xudivmax128x64_inc
;rcx: div0,      rdx: div2,     r8 result PTR       r9 div3
;align 16
w proc public

        mov         r10, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx
        
        mov         [r8], rax
        mov         [r8 + 8], r11

        add         r8, 16
        mov         rcx, r10
        mov         rdx, r9
    
;__spc__2xudivmax128x64_inc
;rcx: div0,      rdx: div2,     r8 result PTR
;align 16
x proc public

        mov         r9, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx
        
        mov         [r8], rax
        mov         [r8 + 8], r11
        
        M_MAIN_UDIV_MAX_128x64_INC r9

        mov         [r8 + 16], r11

        ret
    
x endp
w endp
v endp

;__spc__udivmax128x64_inc
;rcx: div0,      rdx: result hi PTR
align 16
y proc public

        mov         r8, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx

        mov         [r8], r11

        ret

y endp

;__spc__4xudiv128hiXloRlo
;rcx: left + result PTR,      rdx: div PTR
align 16
z proc public

        mov         r8, rdx
        
        M_MAIN_UDIV_128hiXloRlo [rcx], qword ptr [r8]

        add         rcx, 8
        mov         r9, [r8 + 8]
        mov         rdx, [r8 + 16]
        mov         r8, [r8 + 24]
    
;__spc__3xudiv128hiXloRlo
;rcx: left + result PTR,      rdx: div1,      r8: div2,      r9: div0
;align 16
A proc public

        mov         r10, rdx

        M_MAIN_UDIV_128hiXloRlo [rcx], r9

        add         rcx, 8
        mov         rdx, r10
    
;__spc__2xudiv128hiXloRlo
;rcx: left + result PTR,      rdx: div0,      r8: div1
;align 16
B proc public
 
        mov         r9, rdx
        
        M_MAIN_UDIV_128hiXloRlo [rcx], r9
        M_MAIN_UDIV_128hiXloRlo [rcx + 8], r8

        ret

B endp
A endp
z endp

;__usf__divrem128to256x128shl127x15
; rcx = dividend[0...63]		rdx = dividend[64...127],		[r8] = divisor.lo		[r9] = divisor.hi		[rsp + 40] = quoHi PTR
align 16
K proc public

		push		rbx
		push		rbp
		push		rdi
		push		rsi
		push		r12
		push		r13
		push		r14
		push		r15

		mov			r10, rdx
		shld		r10, rcx, 63
		shl			rcx, 63
		shr			rdx, 1
		mov			rbx, r8
		shl			rbx, 15
		mov			rdi, r9
		shld		rdi, r8, 15
		cmp			rdx, rdi
		jae			UDIVREM128X64_0_DIVIDENDHI_GE_DIVISOR
		mov			rax, r10
		div			rdi
		mov			rsi, rdx
		movq		xmm0, rax
		jmp			UDIVREM128X64_0_EXIT

UDIVREM128X64_0_DIVIDENDHI_GE_DIVISOR:
		mov			rax, rdx
		xor			edx, edx
		div			rdi
		mov			r11, rax
		mov			rax, r10
		div			rdi
		mov			rsi, rdx
		movq		xmm0, rax
		movq		xmm1, r11
		punpcklqdq	xmm0, xmm1

UDIVREM128X64_0_EXIT:
		pshufd		xmm1, xmm0, 238
		movq		r15, xmm1
		movq		r14, xmm0
		mov			r10, rbx
		and			r10, -32768
		mov			rax, r10
		mul			r14
		xor			r11d, r11d
		imul		r15, r10
		add			r15, rdx
		sub			rcx, rax
		sbb			rsi, r15
		setb		bpl
		mov			eax, 0
		cmovb		rax, rdi
		mov			r13d, 0
		cmovb		r13, rbx
		mov			rdx, rcx
		neg			rdx
		mov			r15d, 0
		sbb			r15, rsi
		cmp			rbx, rdx
		mov			rdx, rdi
		sbb			rdx, r15
		mov			r15, qword ptr [rsp + 104]
		setb		r12b
		and			r12b, bpl
		add			r13, rcx
		adc			rax, rsi
		test		r12b, r12b
		mov			edx, 0
		cmovne		rdx, rdi
		cmovne		r11, rbx
		add			r11, r13
		adc			rdx, rax
		cmp			rdi, rdx
		jbe			UDIVREM128X64_1_DIVIDENDHI_GE_DIVISOR
		mov			rax, r11
		div			rdi
		mov			rcx, rdx
		movq		xmm0, rax
		jmp			UDIVREM128X64_1_EXIT

UDIVREM128X64_1_DIVIDENDHI_GE_DIVISOR:
		mov			rax, rdx
		xor			edx, edx
		div			rdi
		mov			rsi, rax
		mov			rax, r11
		div			rdi
		mov			rcx, rdx
		movq		xmm0, rax
		movq		xmm1, rsi
		punpcklqdq	xmm0, xmm1 

UDIVREM128X64_1_EXIT:
		movzx		eax, bpl
		sub			r14, rax
		movzx		eax, r12b
		sub			r14, rax
		pshufd		xmm1, xmm0, 238
		movq		rsi, xmm1
		movq		r11, xmm0
		mov			rax, r10
		mul			r11
		imul		rsi, r10
		add			rsi, rdx
		xor			edx, edx
		neg			rax
		sbb			rcx, rsi
		setb		bpl
		mov			r10d, 0
		cmovb		r10, rdi
		mov			esi, 0
		cmovb		rsi, rbx
		mov			r12, rax
		neg			r12
		mov			r13d, 0
		sbb			r13, rcx
		cmp			rbx, r12
		mov			r12, rdi
		sbb			r12, r13
		setb		r12b
		and			r12b, bpl
		movzx		r13d, bpl
		movzx		r12d, r12b
		sub			r11, r13
		sub			r11, r12
		add			rsi, rax
		adc			r10, rcx
		test		r12b, r12b
		cmove		rdi, rdx
		cmovne		rdx, rbx
		add			rdx, rsi
		adc			rdi, r10
		shrd		rdx, rdi, 14
		shr			rdi, 14
		mov			qword ptr [r15 + 8], r14
		mov			rax, rdi
		xor			rax, r9
		mov			rcx, rdx
		xor			rcx, r8
		xor			r10d, r10d
		or			rcx, rax
		sete		r10b
		shl			r10, 63
		mov			rax, 08000000000000001h
		cmp			r8, rdx
		sbb			r9, rdi
		mov			qword ptr [r15], r11
		cmovae		rax, r10

		pop	r15
		pop	r14
		pop	r13
		pop	r12
		pop	rsi
		pop	rdi
		pop	rbp
		pop	rbx

		ret

K endp

; lost source code access, had to restore deleted binary
;__usf__loop_rem128to256x128shl127x15
; rcx = dividend[0...63]		rdx = dividend[64...127],		[r8] = divisor.lo		[r9] = divisor.hi		[rsp + 40] = count		[rsp + 44] = remHi PTR
align 16
L proc public

		push    rbx
		push    rbp
		push    rdi
		push    rsi
		push    r12
		push    r14
		push    r15
		
		mov     r10, rcx
		mov     edi, [rsp + 38h + 28h]
		shld    r9, r8, 0Fh
		shl     r8, 0Fh
		cmp     edi, 71h
		jl      loc_180001535
		mov     rcx, r8
		and     rcx, 0FFFFFFFFFFFF8000h
		jmp     loc_18000144C
		align 16
	
loc_1800013B0:
		mov     rax, r10
		div     r9
		mov     r10, rdx
		movq    xmm0, rax

loc_1800013BE:
		pshufd  xmm1, xmm0, 0EEh
		movq    rdx, xmm0
		mov     rax, rcx
		mul     rdx
		movq    r11, xmm1
		imul    r11, rcx
		add     r11, rdx
		neg     rax
		sbb     r10, r11
		setb    dl
		mov     r11d, 0
		cmovb   r11, r9
		mov     esi, 0
		cmovb   rsi, r8
		mov     rbx, rax
		neg     rbx
		mov     r14d, 0
		sbb     r14, r10
		cmp     r8, rbx
		mov     rbx, r9
		sbb     rbx, r14
		setb    bl
		add     rsi, rax
		adc     r11, r10
		test    bl, dl
		mov     edx, 0
		cmovnz  rdx, r9
		mov     r10d, 0
		cmovnz  r10, r8
		add     r10, rsi
		adc     rdx, r11
		shrd    r10, rdx, 0Fh
		shr     rdx, 0Fh
		lea     eax, [rdi-70h]
		cmp     edi, 0E0h
		mov     edi, eax
		jle     loc_180001537
	
loc_18000144C:
		mov     r11, rdx
		shld    r11, r10, 3Fh
		shr     rdx, 1
		cmp     rdx, r9
		jnb     short loc_18000146C
		mov     rax, r11
		div     r9
		mov     r11, rdx
		movq    xmm0, rax
		jmp     short loc_18000148E

loc_18000146C:
		mov     rax, rdx
		xor     edx, edx
		div     r9
		mov     rsi, rax
		mov     rax, r11
		div     r9
		mov     r11, rdx
		movq    xmm0, rax
		movq    xmm1, rsi
		punpcklqdq xmm0, xmm1

loc_18000148E:
		shl     r10, 3Fh
		pshufd  xmm1, xmm0, 0EEh
		movq    rdx, xmm0
		mov     rax, rcx
		mul     rdx
		movq    rsi, xmm1
		imul    rsi, rcx
		add     rsi, rdx
		sub     r10, rax
		sbb     r11, rsi
		setb    al
		mov     esi, 0
		cmovb   rsi, r9
		mov     ebx, 0
		cmovb   rbx, r8
		mov     rdx, r10
		neg     rdx
		mov     r14d, 0
		sbb     r14, r11
		cmp     r8, rdx
		mov     rdx, r9
		sbb     rdx, r14
		setb    dl
		add     rbx, r10
		adc     rsi, r11
		test    dl, al
		mov     edx, 0
		cmovnz  rdx, r9
		mov     r10d, 0
		cmovnz  r10, r8
		add     r10, rbx
		adc     rdx, rsi
		cmp     rdx, r9
		jb      loc_1800013B0
		mov     rax, rdx
		xor     edx, edx
		div     r9
		mov     r11, rax
		mov     rax, r10
		div     r9
		mov     r10, rdx
		movq    xmm0, rax
		movq    xmm1, r11
		punpcklqdq xmm0, xmm1
		jmp     loc_1800013BE

loc_180001535:
		mov     eax, edi

loc_180001537: 
		add     al, 0Fh
		mov     rdi, rdx
		mov     ecx, eax
		shld    rdi, r10, cl
		mov     r11, rdx
		shld    r11, r10, 3Fh
		shl     r10, cl
		xor     esi, esi
		test    al, 40h
		cmovnz  rdi, r10
		cmovnz  r10, rsi
		shr     rdx, 1
		xor     cl, 7Fh
		shrd    r11, rdx, cl
		shr     rdx, cl
		test    cl, 40h
		cmovnz  r11, rdx
		cmovnz  rdx, rsi
		test    al, al
		mov     ebx, 0
		cmovns  rbx, rdi
		cmovns  rsi, r10
		cmovs   r11, r10
		cmovs   rdx, rdi
		cmp     rdx, r9
		jnb     short loc_18000159D
		mov     rax, r11
		div     r9
		mov     r11, rdx
		movq    xmm0, rax
		jmp     short loc_1800015BF
	
loc_18000159D:
		mov     rax, rdx
		xor     edx, edx
		div     r9
		mov     rcx, rax
		mov     rax, r11
		div     r9
		mov     r11, rdx
		movq    xmm0, rax
		movq    xmm1, rcx
		punpcklqdq xmm0, xmm1
	
loc_1800015BF:
		pshufd  xmm1, xmm0, 0EEh
		movq    rdi, xmm1
		movq    rdx, xmm0
		mov     rcx, r8
		and     rcx, 0FFFFFFFFFFFF8000h
		mov     rax, rcx
		mul     rdx
		xor     r10d, r10d
		imul    rdi, rcx
		add     rdi, rdx
		sub     rbx, rax
		sbb     r11, rdi
		mov     eax, 0
		cmovb   rax, r9
		mov     r14d, 0
		cmovb   r14, r8
		setb    dl
		mov     r15, rbx
		neg     r15
		mov     r12d, 0
		sbb     r12, r11
		cmp     r8, r15
		mov     r15, r9
		sbb     r15, r12
		setb    bpl
		add     r14, rbx
		adc     rax, r11
		test    bpl, dl
		mov     edx, 0
		cmovnz  rdx, r9
		cmovnz  r10, r8
		add     r10, r14
		adc     rdx, rax
		cmp     rdx, r9
		jnb     short loc_180001651
		mov     rax, r10
		div     r9
		mov     r10, rdx
		movq    xmm0, rax
		jmp     short loc_180001673
	
loc_180001651:
		mov     rax, rdx
		xor     edx, edx
		div     r9
		mov     r11, rax
		mov     rax, r10
		div     r9
		mov     r10, rdx
		movq    xmm0, rax
		movq    xmm1, r11
		punpcklqdq xmm0, xmm1
	
loc_180001673:
		pshufd  xmm1, xmm0, 0EEh
		movq    rbx, xmm1
		movq    rdx, xmm0
		mov     rax, rcx
		mul     rdx
		mov     r11, rax
		imul    rbx, rcx
		add     rbx, rdx
		xor     eax, eax
		sub     rsi, r11
		sbb     r10, rbx
		setb    cl
		mov     edx, 0
		cmovb   rdx, r9
		mov     r11d, 0
		cmovb   r11, r8
		mov     rbx, rsi
		neg     rbx
		mov     r14d, 0
		sbb     r14, r10
		cmp     r8, rbx
		mov     rbx, r9
		sbb     rbx, r14
		setb    bl
		add     r11, rsi
		adc     rdx, r10
		test    bl, cl
		cmovz   r9, rax
		cmovnz  rax, r8
		add     rax, r11
		adc     r9, rdx
		shrd    rax, r9, 0Fh
		shr     r9, 0Fh
		mov     rdi, [rsp+38h+30h]
		mov     [rdi], r9
		
		pop     r15
		pop     r14
		pop     r12
		pop     rsi
		pop     rdi
		pop     rbp
		pop     rbx
		ret
	
L endp

;__rcpdivf128
; rcx = x[0...63]		rdx = x[64...127],		[r8] = quo PTR
M proc public

	push		rbx
	push		rbp
	push		rdi
	push		rsi
	push		r12
	push		r13
	push		r14
	push		r15

	movq		xmm2, rcx
	movq		xmm3, rdx
	movq		xmm4, r8

	mov			r14, rdx
	xor			eax, eax
	or			rdx, rcx
	setnz		al
	mov			r15, rcx
	shl			r15, 15
	shld		r14, rcx, 15
	shl			rax, 47
	mov			rdx, 0000800000000000h
	add			rdx, rax
	cmp			rdx, r14
	jae			UDIVREM128X64_0_DIVIDENDHI_GE_DIVISOR
	xor			eax, eax
	div			r14
	mov			rcx, rdx
	movq		xmm0, rax
	jmp			UDIVREM128X64_0_EXIT

UDIVREM128X64_0_DIVIDENDHI_GE_DIVISOR:
	mov			rax, rdx
	xor			edx, edx
	div			r14
	mov			r11, rax
	xor			eax, eax
	div			r14
	mov			rcx, rdx
	movq		xmm0, rax
	movq		xmm1, r11
	punpcklqdq	xmm0, xmm1

UDIVREM128X64_0_EXIT:
	pshufd		xmm1, xmm0, 238
	movq		r13, xmm1
	movq		r12, xmm0
	xor			edi, edi
	mov			r11, r15
	and			r11, -32768
	mov			rax, r11
	mul			r12
	mov			rsi, rax
	imul		r13, r11
	add			r13, rdx
	neg			rax
	mov			rdx, rcx
	sbb			rdx, r13
	setb		bl
	mov			r9d, 0
	cmovb		r9, r14
	mov			r8d, 0
	cmovb		r8, r15
	mov			rbp, rax
	neg			rbp
	mov			r10d, 0
	sbb			r10, rdx
	cmp			r15, rbp
	mov			rbp, r14
	sbb			rbp, r10
	setb		bpl
	and			bpl, bl
	add			r8, rax
	adc			r9, rdx
	test		bpl, bpl
	mov			edx, 0
	cmovne		rdx, r14
	cmovne		rdi, r15
	add			rdi, r8
	adc			rdx, r9
	cmp			rdx, r14
	jae			UDIVREM128X64_1_DIVIDENDHI_GE_DIVISOR
	mov			rax, rdi
	div			r14
	mov			rdi, rdx
	movq		xmm0, rax
	jmp			UDIVREM128X64_1_EXIT

UDIVREM128X64_1_DIVIDENDHI_GE_DIVISOR:
	mov			rax, rdx
	xor			edx, edx
	div			r14
	mov			rbx, rax
	mov			rax, rdi
	div			r14
	mov			rdi, rdx
	movq		xmm0, rax
	movq		xmm1, rbx
	punpcklqdq	xmm0, xmm1

UDIVREM128X64_1_EXIT:
	neg			rsi
	sbb			rcx, r13
	sbb			r12, 0
	movzx		eax, bpl
	sub			r12, rax
	pshufd		xmm1, xmm0, 238
	movq		rcx, xmm1
	movq		r10, xmm0
	mov			rax, r11
	mul			r10
	imul		rcx, r11
	add			rcx, rdx
	xor			edx, edx
	neg			rax
	sbb			rdi, rcx
	setb		cl
	mov			r11d, 0
	cmovb		r11, r14
	mov			esi, 0
	cmovb		rsi, r15
	mov			r8, rax
	neg			r8
	mov			r9d, 0
	sbb			r9, rdi
	cmp			r15, r8
	mov			r8, r14
	sbb			r8, r9
	setb		r8b
	and			r8b, cl
	movzx		ecx, cl
	movzx		r8d, r8b
	sub			r10, rcx
	sub			r10, r8
	add			rsi, rax
	adc			r11, rdi
	test		r8b, r8b
	cmove		r14, rdx
	cmovne		rdx, r15
	add			rdx, rsi
	adc			r14, r11
	shrd		rdx, r14, 14
	shr			r14, 14
	movq		r9, xmm4
	mov			rax, r14
	movq		rdi, xmm3
	xor			rax, rdi
	mov			rcx, rdx
	movq		r11, xmm2
	xor			rcx, r11
	xor			r8d, r8d
	or			rcx, rax
	setz		r8b
	shl			r8, 63
	mov			rax, 08000000000000001h
	cmp			r11, rdx
	sbb			rdi, r14

	mov			qword ptr [r9], r10
	mov			qword ptr [r9 + 8], r12
	cmovae		rax, r8
	
	pop			r15
	pop			r14
	pop			r13
	pop			r12
	pop			rsi
	pop			rdi
	pop			rbp
	pop			rbx

	ret

M endp

end