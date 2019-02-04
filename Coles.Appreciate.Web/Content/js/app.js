
function Response(obj) {
    if (!obj)
        obj = {};
    this.ResponseId = obj.ResponseId || null;
    this.ResponseText = obj.ResponseText || null;
}

function Person(UserId, FullName) {
    this.UserId  = UserId;
    this.FullName = (FullName || null);
    this.FirstName = null;
    this.LastName = null;
    this.LineManager = null;
    this.Response = null;//'1234'//ko.observable(new Response('init'));
    this.unresolved = ko.observable(false);
    this.unresolvedPotentials = ko.observableArray();
}

function Reason(obj) {
    if (!obj)
        obj = {};

    this.ReasonId = obj.ReasonId || null;
    this.ReasonText = obj.ReasonText || null;
    this.IsSelected = ko.observable(obj.IsSelected || false);


}



var _MODE = Object.freeze({ 'CREATE': 1, 'RESPOND': 2 });
var vm = function(){
    var self = this;

    self.hello = '??hello';


    self.user = ko.observable(new Person('mvmanley'));
    self.user().Response = ko.observable(new Response(null));
    self.config = {
        docMode: _MODE.CREATE,
        maxSelectableReasons: 3,
        alertifyDefaultTimeout: 1,
        awaitingResponses: ko.observable(false),
        awaitingTarget: ko.observable(false),
        awaitingSource: ko.observable(false),
        awaitingAlertUsers: ko.observable(false)


    }

    self.resources = {
        Save: { awaiting: ko.observable(false) },
        Load: { awaiting: ko.observable(false) },
        ResponseTypes: { awaiting: ko.observable(false), data: ko.observableArray([]) },
        ReasonTypes: { awaiting: ko.observable(false), data: ko.observableArray([]) }
    }

    self.onEnterKey = function () {
        let data = this;

        if (data.Event.keyCode == 13) {
            data.function(data);
        }
        
    }


    self.getUserSearch = function (data) {

        let url = "http://localhost:49930/api/v1/person/findUser?search=" + data.searchTerm()

        data.searchAwaitingFlag(true);

        $.get(url, function (resp) {
            let unresolved = '';
            let person = null;
            let exists = false;
            data.searchResults.length = 0;
            ko.utils.arrayForEach(resp, function (rs) {

                

                if (rs.Results.length == 1) {
                    exists = data.searchResults().some(function (obj) { return obj.UserId == rs.Results[0].UserId });
                        if (!exists) {
                            data.searchResults.push(new Person(rs.Results[0].UserId, rs.Results[0].UserName))
                        }
                    } else if (rs.Results.length) {

                        person = new Person(rs.SearchTerm)
                        person.unresolved(true);

                        ko.utils.arrayForEach(rs.Results, function (ur) {
                            person.unresolvedPotentials.push(new Person(rs.Results[0].UserId, rs.Results[0].UserName));

                        });
                        data.searchResults.push(person);
                    } else {
                        if (unresolved.length != 0) {
                            unresolved += ','
                        }
                        unresolved += rs.SearchTerm;
                    }

            });

            data.searchTerm(unresolved);
            if (unresolved) {
                alertify.warning('Some names unresolved');
            } else {
                alertify.success('Success');
            }
            

        }).fail(function () {
            alertify.error('Fail');
        }).always(function () {

            data.searchAwaitingFlag(false);
        })

    }

    //http://localhost:49930/api/v1/ReasonTypes


    self.getResponseTypes = function () {
        let url = "http://localhost:49930/api/v1/ResponseTypes"
        let resource = self.resources.ResponseTypes;

        //self.config.awaitingResponses(true);
        resource.awaiting(true);
        $.get(url, function (resp) {

            self.responses().length = 0;
            ko.utils.arrayForEach(resp, function (obj) {
                resource.data.push(new Response(obj))
            })

            alertify.success('Success');

        }).fail(function () {
            alertify.error('Fail');
        }).always(function () {

            resource.awaiting(false);
        })


    }

    self.saveAppreciate = function () {
        let url = "http://localhost:49930//api/v1/Appreciations"
        let payload = {
            AppreciationId: 0, CreatedBy: 'testera',
            AppreciationReasons: []
        };
        let resource = self.resources.Save;
        resource.awaiting(true);


        ko.utils.arrayForEach(self.resources.ReasonTypes.data(), function (reason) {
            reason.AppreciationId=0
            payload.AppreciationReasons.push(reason);

        });


        $.post(url, payload, function (resp) {
            alertify.success('Success');
        }).fail(function (resp) {
            alertify.error('Fail');
        }).always(function () {

            resource.awaiting(false);
        })
    }

    self.getReasonTypes = function () {
        let url = "http://localhost:49930/api/v1/ReasonTypes"
        let resource = self.resources.ReasonTypes;

        //self.config.awaitingResponses(true);
        resource.awaiting(true);
        $.get(url, function (resp) {

            self.responses().length = 0;
            ko.utils.arrayForEach(resp, function (obj) {
                resource.data.push(new Reason(obj))
            })

            alertify.success('Success');

        }).fail(function () {
            alertify.error('Fail');
            }).always(function () {

                resource.awaiting(false);
            })


    }
    self.searchTarget = ko.observable('init');
    self.searchSource = ko.observable('mm');
    self.searchAlertUsers = ko.observable('dd');
    self.alertUserLinemanager = false;
    self.alertTargetsLinemanager = { value: false, IsCurrent: false, LineManagers: [] };
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

    /*
    self.reasons.push(new Reason('helpful'));
    self.reasons.push(new Reason('professional'));
    self.reasons.push(new Reason('inspiring',true));
    self.reasons.push(new Reason('dedicated',true));
    */

    self.teammembers.push(new Person('sgough'));
    self.teammembers.push(new Person('pmurray'));

    self.alertUsers.push(new Person('czheng3'));

    self.agrees.push(new Person('jsmith'));
    self.agrees.push(new Person('sprakash'));

    /*
    self.responses.push(new Response('congrats'));
    self.responses.push(new Response('wellDone'));
    self.responses.push(new Response('amazing'));
    self.responses.push(new Response('thankyou'));
    */

    self.reasonsSelected = ko.pureComputed(function(){
        return ko.utils.arrayFilter(self.resources.ReasonTypes.data(),function(reason){
            return reason.IsSelected();
        })
    });

    self.reasonsNotSelected = ko.pureComputed(function(){
        return ko.utils.arrayFilter(self.resources.ReasonTypes.data(),function(reason){
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

    self.getAppreciate = function () {
        let url = "http://localhost:49930/api/v1/Appreciations/" + targetAppreciateId;
        let resource = self.resources.Load;

        //self.config.awaitingResponses(true);
        resource.awaiting(true);
        $.get(url, function (resp) {

            let arr = [];

            ko.utils.arrayForEach(resp.AppreciationReasons, function (obj) {
                arr.push(obj.ReasonId);
            });

            let n = null;
            ko.utils.arrayForEach(self.resources.ReasonTypes.data(), function (obj) {
                if (arr.length) {
                    n = arr.indexOf(obj.ReasonId);
                    if (n != -1) {
                        obj.IsSelected(true);
                        arr.splice(n, 1);
                    }
                }
            });



            alertify.success('Success');

        }).fail(function () {
            alertify.error('Fail');
        }).always(function () {

            resource.awaiting(false);
        })


    }
}


ko.applyBindings(new vm());

