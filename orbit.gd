extends Panel


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var child_nodes
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func orbit_point(var a, var obj):
	var c = obj.get_global_position()
	a = a - obj.get_global_rect().size/2
	var point_1 = (a+(c-a).rotated(0.002))
	obj.set_global_position(point_1)
	
func orbit_point_ellipse(var a, var obj):
	var c = obj.get_global_position()
	a = a - obj.get_global_rect().size/2
	var delta = abs(Vector2.DOWN.angle_to(a-c)) / 300
	print(delta)
	var point_1 = (a+(c-a).rotated(0.002 + delta))
	obj.set_global_position(point_1)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	for _i in self.get_children():
		var d = _i.get_global_position()
		var q = self.get_global_position() - _i.get_global_rect().size/2
		#_i.set_global_position(q + (d-q).rotated(0.002))
		orbit_point_ellipse(self.get_global_position() + self.get_global_rect().size/2,_i)
#	pass
