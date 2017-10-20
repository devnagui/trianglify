(function() {
	var app = angular.module('pyramid', []);
	app.controller('TriangleController', triangleController);
	triangleController.$inject = [ '$scope', '$http' ];
	function triangleController($scope, $http) {
		var triangle = {
				SideA:0,
				SideB:0,
				SideC:0
		};
		var controller = this;

		this.identify = function() {
			controller.triangle.TriangleType="";
			controller.triangle.Error="";
			console.log("Sending triangle:");
			console.log(controller.triangle);
            $http.post('api/trianglify/identifyPost', controller.triangle).then(
					function(response) {
						console.log("success")
                        console.log(response);
                        if (response.data.Error != null && response.data.Error != "") {
                            controller.triangle.Error = response.data.Error;
                        } else {
                            controller.triangle.TriangleType = response.data.TriangleType;
                        }
						
					}, function(response) {
						console.log("error");
						console.log(response);
                        controller.triangle.Error = response.data.Error;
                        controller.triangle.Error = "teste";
					});
		};

	}
	;
})();
