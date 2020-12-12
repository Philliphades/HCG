a,b,c->p.( a + b + c ) / 2
a,b,c,p->S.sqrt ( p * ( p - a ) * ( p - b ) * ( p - c ) )
a,b,C->S.( a * b * sin C ) / 2
a,c,B->S.( a * c * sin B ) / 2
b,c,A->S.( b * c * sin A ) / 2
a,ha->S.a * ha / 2
b,hb->S.b * hb / 2
c,hc->S.c * hc / 2
a,b,A->B.arcsin ( b * sin A / a )
a,b,B->A.arcsin ( a * sin B / b )
a,c,A->C.arcsin ( c * sin A / a )
a,c,C->A.arcsin ( a * sin C / c )
b,c,B->C.arcsin ( c * sin B / b )
b,c,C->B.arcsin ( b * sin C / c )
A,B->C.180 - A - B
A,C->B.180 - A - C
B,C->A.180 - C - B
a,C->hb.a * sin C
a,B->hc.a * sin B
c,A->hb.c * sin A
c,B->ha.c * sin B
b,A->hc.b * sin A
b,C->ha.b * sin C
a,A,B->b.a * sin B / sin A
a,A,C->c.a * sin C / sin A
b,B,A->a.b * sin A / sin B
b,B,C->c.b * sin C / sin B
c,C,A->a.c * sin A / sin C
c,C,B->b.c * sin B / sin C
a,b,C->c.sqrt ( a * a + b * b - 2 * a * b * cos C )
a,c,B->b.sqrt ( a * a + c * c - 2 * a * c * cos B )
b,c,A->a.sqrt ( b * b + c * c - 2 * b * c * cos A )