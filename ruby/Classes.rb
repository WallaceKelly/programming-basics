# color = "red"
# sides = 3
# puts "My #{color} shape has #{sides} sides."

# color1 = "red"
# sides1 = 3
# color2 = "blue"
# sides2 = 4
# puts "My #{color1} shape has #{sides1} sides,"
# puts "but my #{color2} shape has #{sides2}."

class Shape
    attr_reader :color
    attr_reader :sides
    def initialize(color, sides)
        @color = color;
        @sides = sides;
    end
end

shape1 = Shape.new("red", 3)
shape2 = Shape.new("blue", 4)

shape1.sides

puts "My #{shape1.color} shape has #{shape1.sides} sides,"
puts "but my #{shape2.color} shape has #{shape2.sides}."
