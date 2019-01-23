
function Response(ResponseId) {
    this.ResponseId = ResponseId;

}

function Person(UserId, FullName) {
    this.UserId  = UserId;
    this.FullName = (FullName || null);
    this.FirstName = null;
    this.LastName = null;
    this.LineManager = null;
    this.Response = null ;//'1234'//ko.observable(new Response('init'));
}

function Reason(ReasonId,IsSelected){
    this.ReasonId = ReasonId;
    this.IsSelected = ko.observable(IsSelected || false);


}



var _MODE = Object.freeze({ 'CREATE': 1, 'RESPOND': 2 });
var vm = function(){
    var self = this;

    self.hello = '??hello';


    self.user = ko.observable(new Person('mvmanley'));
    self.user().Response = ko.observable(new Response(null));
    self.config = {
        docMode: _MODE.RESPOND,
        maxSelectableReasons: 3,
        alertifyDefaultTimeout:1


    }
    

    self.alertUserLinemanager = false;
    self.alertTargetsLinemanager = false;
    self.alertUsers = ko.observableArray();
    self.IsPrivate = true;  //Will not be seen by anyone outside of sources/targets lists
    self.comment = 'Great Work!';
    self.agrees   = ko.observableArray();        //Persons

    self.sources = ko.observableArray();        //Persons
    self.targets = ko.observableArray();        //Persons
    self.reasons = ko.observableArray();        //Reasons
    self.responses = ko.observableArray();      //Reasons

    self.teammembers = ko.observableArray();    //Persons

    self.sources.push(new Person('mvmanley'));

    self.targets.push(new Person('cellis'));
    self.targets.push(new Person('jzapantis'));

    self.reasons.push(new Reason('helpful'));
    self.reasons.push(new Reason('professional'));
    self.reasons.push(new Reason('inspiring',true));
    self.reasons.push(new Reason('dedicated',true));


    self.teammembers.push(new Person('sgough'));
    self.teammembers.push(new Person('pmurray'));

    self.alertUsers.push(new Person('czheng3'));

    self.agrees.push(new Person('jsmith'));
    self.agrees.push(new Person('sprakash'));

    self.responses.push(new Response('congrats'));
    self.responses.push(new Response('wellDone'));
    self.responses.push(new Response('amazing'));
    self.responses.push(new Response('thankyou'));


    self.reasonsSelected = ko.pureComputed(function(){
        return ko.utils.arrayFilter(self.reasons(),function(reason){
            return reason.IsSelected();
        })
    });

    self.reasonsNotSelected = ko.pureComputed(function(){
        return ko.utils.arrayFilter(self.reasons(),function(reason){
            return !reason.IsSelected();
        })
    });

    

    self.reasonSelect = function (reason) {
        if (!reason.IsSelected() && self.reasonsSelected().length >= self.config.maxSelectableReasons) {
            alertify.warning('No more than ' + self.config.maxSelectableReasons + ' reasons can be selected.', self.config.alertifyDefaultTimeout);

            return;
        }
        reason.IsSelected(!reason.IsSelected());
    }


    self.teamMemberSelect = function(teamMember){
        self.teamMemberToggle(teamMember,true);
    }

    self.teamMemberDeSelect = function(teamMember){
        self.teamMemberToggle(teamMember,false);
    }

    self.teamMemberToggle= function(teamMember,isSelect){

        let from    = ( isSelect  ? self.teammembers : self.targets);
        let to      = (!isSelect  ? self.teammembers : self.targets);

        
        from.remove(function(obj){
            return obj.UserId == teamMember.UserId;
        });
        to.push(teamMember);
    }
    self.addUser = function () {
        let arr = this;
        let newUserId = prompt('What user?');
        let exists = arr().some(function (obj) { return obj.UserId == newUserId });
        if (exists) {
            alertify.error("User '" + newUserId + "' is already exists.", self.config.alertifyDefaultTimeout);
        } else {
            arr.push(new Person(newUserId));
        }
        
    }
    self.removeFromArray = function () {
        let obj = this;
        obj.array.remove(function (u) {
            return u[obj.key] == obj.value;
        });
    }

    self.responseSelect = function () {
        let data = this;
        //self.user.Response(data);

        self.user().Response(data);

    }


    self.responseReset = function () {
        let data = this;
        //self.user.Response(data);

        self.user().Response(new Response(null));

    }


}

ko.applyBindings(new vm());