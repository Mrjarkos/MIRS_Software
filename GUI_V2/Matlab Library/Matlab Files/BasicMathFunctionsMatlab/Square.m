function [x,y] = Square(A, f, Offset, duty, Ph, length)
T = 1/f;
x = 0:T/length:T;
w = 2*pi*f;
Ph = deg2rad(Ph);
y = A*square(w*x+Ph,duty)+Offset;
end

