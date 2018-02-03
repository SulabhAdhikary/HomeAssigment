export class OcasActivitySignup {
  constructor(
    public firstName: string = '',
    public lastName: string = '',
    public email: string = '',
    public activityId: string = '',
    public activityName: string = '',
    public activity: OcasActivity = new OcasActivity()) {
  }

  
}

export class OcasActivity {
  id: number;
  name: string;
}


/*
  id = t.Id.ToString(),
  activityId = t.ActivityId.ToString(),
  firstName = t.FirstName,
  lastName = t.LastName,
  email = t.Email,
  activityName = t.Activity.Name
*/
