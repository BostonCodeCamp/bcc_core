using CodeCamp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeCamp.Common.Interfaces
{
    public interface ICodeCampRepository : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ccevent"></param>
        void AddEvent(Event ccevent);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        void AddPresenter(Presenter presenter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionPresenter"></param>
        void AddSessionPresenter(SessionPresenter sessionPresenter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        void AddSession(Session session);

        /// <summary>
        /// ShortName of default event (should be a public event)
        /// </summary>
        string DefaultEventShortName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Event GetDefaultPublicEvent();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortName"></param>
        /// <param name="defaultShortName"></param>
        /// <returns></returns>
        Event GetEvent(string shortName, string defaultShortName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortName"></param>
        /// <param name="defaultShortName"></param>
        /// <param name="publicOnly"></param>
        /// <returns></returns>
        Event GetEvent(string shortName, string defaultShortName, bool publicOnly);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortName"></param>
        /// <param name="publicOnly"></param>
        /// <returns></returns>
        Event GetEvent(string shortName, bool publicOnly);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<Session> GetEventCurrentPublicSessions();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<Session> GetEventPublicSessions(int eventId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<Event> GetEventsQueryable();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<Presenter> GetPresentersQueryable();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<Session> GetSessionsQueryable();

        /// <summary>
        /// Removes event from database.  Caller must have removed contained objects.
        /// </summary>
        /// <param name="ccEvent"></param>
        void RemoveEvent(Event ccEvent);

        /// <summary>
        /// Removes presenters from database.
        /// </summary>
        /// <param name="presenters"></param>
        void RemovePresenters(List<Presenter> presenters);

        /// <summary>
        /// Removes session presenters from database.
        /// </summary>
        /// <param name="sessionPresenters"></param>
        void RemoveSessionPresenters(List<SessionPresenter> sessionPresenters);

        /// <summary>
        /// Removes session from database.  Caller must have removed contained objects.
        /// </summary>
        /// <param name="sessions"></param>
        void RemoveSessions(List<Session> sessions);

        /// <summary>
        /// DbContext implementation
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
