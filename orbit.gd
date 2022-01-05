extends Panel


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var child_nodes
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	for _i in self.get_children():
		var d = _i.get_global_position()
		var q = self.get_global_position() - _i.get_global_rect().size/2
		_i.set_global_position(q + (d-q).rotated(0.002))
#	pass
