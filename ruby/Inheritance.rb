class Shape
    def get_color; @color; end;
    def get_thickness; @thickness; end;

    def get_sides
        raise "Abstract shapes don't have sides!"
    end

    def initialize(color, thickness) #, sides)
        @color = color
        @thickness = thickness
    end
end

class Triangle < Shape
    def get_sides; 3; end;
end

class Square < Shape
    def get_sides; 4; end;
end

shape = Square.new("red", 20)
puts "The #{shape.class.name} is #{shape.get_color}."
puts "A #{shape.class.name} has #{shape.get_sides} sides."
