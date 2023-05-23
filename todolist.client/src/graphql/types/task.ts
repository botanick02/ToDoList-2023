import { ITask } from "../../redux/types";

export interface ITasksFetchData {
  data: ITasksFetch;
}

interface ITasksFetch{
    tasks: IGetTasks;
}
interface IGetTasks {
  getTasks: ITask[];
}
